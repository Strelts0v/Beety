using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Security;
using Newtonsoft.Json.Linq;
using Services;

namespace Beety.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly ITokenStoreService _tokenStoreService;

        public AccountController(
            IUsersService usersService,
            ITokenStoreService tokenStoreService)
        {
            _usersService = usersService;
            _tokenStoreService = tokenStoreService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody]  User loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("user is not set.");
            }

            var user = _usersService.FindUser(loginUser.Login, loginUser.Password);
            if (user == null || !user.IsActive)
            {
                return Unauthorized();
            }

            var accessToken = _tokenStoreService.CreateJwtTokens(user, null);
            return Ok(new { access_token = accessToken});
        }

        [HttpGet("[action]")]
        [Authorize(Policy = CustomRoles.Admin)]
        public IActionResult Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity.FindFirst(ClaimTypes.UserData);
            var userId = userDataClaim.Value;

            return Ok(new
            {
                Id = 1,
                Title = "Hello from My Protected Admin Api Controller! [Authorize(Policy = CustomRoles.Admin)]",
                Username = User.Identity.Name,
                UserData = userId,
                Roles = claimsIdentity.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList()
            });
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult RefreshToken([FromBody]JToken jsonBody)
        {
            var refreshToken = jsonBody.Value<string>("refreshToken");
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return BadRequest("refreshToken is not set.");
            }

            var token = _tokenStoreService.FindToken(refreshToken);
            if (token == null)
            {
                return Unauthorized();
            }

            var accessToken = _tokenStoreService.CreateJwtTokens(token.User, refreshToken);
            return Ok(new { access_token = accessToken});
        }

        [AllowAnonymous]
        [HttpGet("[action]"), HttpPost("[action]")]
        public bool Logout([FromBody]JToken jsonBody)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userIdValue = claimsIdentity?.FindFirst(ClaimTypes.UserData)?.Value;
            var refreshToken = jsonBody.Value<string>("refreshToken");

            // The Jwt implementation does not support "revoke OAuth token" (logout) by design.
            // Delete the user's tokens from the database (revoke its bearer token)
            _tokenStoreService.RevokeUserBearerTokens(userIdValue, refreshToken);

            return true;
        }
    }
}