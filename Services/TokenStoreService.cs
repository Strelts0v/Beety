using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Common;
using DataAccess.EntitiesRepositories.SecurityRepositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Security;

namespace Services
{
    public interface ITokenStoreService
    {
        void AddUserTokenAsync(UserToken userToken);
        void AddUserTokenAsync(User user, string refreshToken, string accessToken, string refreshTokenSource);
        bool IsValidToken(string accessToken, int userId);
        void DeleteExpiredTokensAsync();
        UserToken FindToken(string refreshToken);
        void DeleteToken(string refreshToken);
        void DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource);
        void InvalidateUserTokens(int userId);
        string CreateJwtTokens(User user, string refreshTokenSource);
        void RevokeUserBearerTokens(string userIdValue, string refreshToken);
    }

    public class TokenStoreService : ITokenStoreService
    {
        private readonly ISecurityService _securityService;
        private readonly IOptionsSnapshot<BearerTokensOptions> _configuration;
        private readonly IRolesService _rolesService;
        private readonly IUserTokenRepository _userTokenRepository;

        public TokenStoreService(
            ISecurityService securityService,
            IRolesService rolesService,
            IUserTokenRepository userTokenRepository,
            IOptionsSnapshot<BearerTokensOptions> configuration)
        {
            _securityService = securityService;
            _rolesService = rolesService;
            _userTokenRepository = userTokenRepository;
            _configuration = configuration;
        }

        public void AddUserTokenAsync(UserToken userToken)
        {
            if (!_configuration.Value.AllowMultipleLoginsFromTheSameUser)
            {
                InvalidateUserTokens(userToken.UserId);
            }
             DeleteTokensWithSameRefreshTokenSourceAsync(userToken.RefreshTokenIdHashSource);
            _userTokenRepository.Add(userToken);
            _userTokenRepository.SaveChanges();
        }

        public void AddUserTokenAsync(User user, string refreshToken, string accessToken, string refreshTokenSource)
        {
            var now = DateTimeOffset.UtcNow;
            var token = new UserToken
            {
                UserId = user.Id,
                RefreshTokenIdHash = _securityService.GetSha256Hash(refreshToken),
                RefreshTokenIdHashSource = string.IsNullOrWhiteSpace(refreshTokenSource) ?
                                           null : _securityService.GetSha256Hash(refreshTokenSource),
                AccessTokenHash = _securityService.GetSha256Hash(accessToken),
                RefreshTokenExpiresDateTime = now.AddMinutes(_configuration.Value.RefreshTokenExpirationMinutes),
                AccessTokenExpiresDateTime = now.AddMinutes(_configuration.Value.AccessTokenExpirationMinutes)
            };
            AddUserTokenAsync(token);
        }

        public void DeleteExpiredTokensAsync()
        {
            var now = DateTimeOffset.UtcNow;
            var expiredTokens = _userTokenRepository.GetAll().Where(x => x.RefreshTokenExpiresDateTime < now).ToList();
            expiredTokens.ForEach(userToken => { _userTokenRepository.Delete(userToken); });
            _userTokenRepository.SaveChanges();
        }

        public void DeleteToken(string refreshToken)
        {
            var token = FindToken(refreshToken);
            if (token != null)
            {
                _userTokenRepository.Delete(token);
                _userTokenRepository.SaveChanges();
            }
        }

        public void DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenIdHashSource))
            {
                return;
            }
            _userTokenRepository.GetAll().Where(t => t.RefreshTokenIdHashSource == refreshTokenIdHashSource).ToList()
                .ForEach(userToken => { _userTokenRepository.Delete(userToken); });
            _userTokenRepository.SaveChanges();
        }

        public void RevokeUserBearerTokens(string userIdValue, string refreshToken)
        {
            if (!string.IsNullOrWhiteSpace(userIdValue) && int.TryParse(userIdValue, out int userId))
            {
                if (_configuration.Value.AllowSignoutAllUserActiveClients)
                {
                    InvalidateUserTokens(userId);
                }
            }

            if (!string.IsNullOrWhiteSpace(refreshToken))
            {
                var refreshTokenIdHashSource = _securityService.GetSha256Hash(refreshToken);
                DeleteTokensWithSameRefreshTokenSourceAsync(refreshTokenIdHashSource);
            }
            DeleteExpiredTokensAsync();
        }

        public UserToken FindToken(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return null;
            }
            var refreshTokenIdHash = _securityService.GetSha256Hash(refreshToken);

            return _userTokenRepository.Get(x => x.RefreshTokenIdHash == refreshTokenIdHash).FirstOrDefault();
        }

        public void InvalidateUserTokens(int userId)
        {
            _userTokenRepository.GetAll().Where(x => x.Id == userId).ToList()
                .ForEach(userToken => { _userTokenRepository.Delete(userToken); });
            _userTokenRepository.SaveChanges();
        }

        public bool IsValidToken(string accessToken, int userId)
        {
            var accessTokenHash = _securityService.GetSha256Hash(accessToken);
            var userToken = _userTokenRepository.Get(x => x.UserId == userId && x.AccessTokenHash == accessTokenHash).FirstOrDefault();

            return userToken?.AccessTokenExpiresDateTime >= DateTimeOffset.UtcNow;
        }

        public string CreateJwtTokens(User user, string refreshTokenSource)
        {
            var accessToken = CreateAccessTokenAsync(user);
            var refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            AddUserTokenAsync(user, refreshToken, accessToken, refreshTokenSource);

            return accessToken;
        }

        private string CreateAccessTokenAsync(User user)
        {
            var claims = CreateClaims(user);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Value.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _configuration.Value.Issuer,
                audience: _configuration.Value.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_configuration.Value.AccessTokenExpirationMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> CreateClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration.Value.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.UserData, user.Id.ToString())
            };
            var roles = _rolesService.FindUserRolesAsync(user.Id);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            return claims;
        }
    }
}
