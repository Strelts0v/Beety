using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Services
{
    public interface ITokenValidatorService
    {
        Task ValidateAsync(TokenValidatedContext context);
    }

    public class TokenValidatorService : ITokenValidatorService
    {
        private readonly IUsersService _usersService;
        private readonly ITokenStoreService _tokenStoreService;

        public TokenValidatorService(IUsersService usersService, ITokenStoreService tokenStoreService)
        {
            _usersService = usersService;
            _tokenStoreService = tokenStoreService;
        }

        public Task ValidateAsync(TokenValidatedContext context)
        {
            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return null;
            }

            var userIdString = claimsIdentity.FindFirst(ClaimTypes.UserData).Value;
            if (!int.TryParse(userIdString, out var userId))
            {
                context.Fail("This is not our issued token. It has no user-id.");
                return null;
            }

            var user = _usersService.FindUser(userId);
            if (user == null || !user.IsActive)
            {
                context.Fail("This token is expired. Please login again.");
            }

            var accessToken = context.SecurityToken as JwtSecurityToken;
            if (string.IsNullOrWhiteSpace(accessToken?.RawData) || !_tokenStoreService.IsValidToken(accessToken.RawData, userId))
            {
                context.Fail("This token is not in our database.");
            }
            return Task.CompletedTask;
        }
    }
}
