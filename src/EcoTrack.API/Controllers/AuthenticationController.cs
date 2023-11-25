using EcoTrack.API.Models;
using EcoTrack.BL.Services.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcoTrack.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class AuthenticationController: Controller
    {
        private readonly IUsersService _usersService;
        private readonly IConfiguration _config;
        public AuthenticationController(IUsersService usersService, IConfiguration config) 
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        [HttpPost]
        public async Task<ActionResult<string>> AuthenticateUser(UserCredentials userCredentials)
        {
            var user =await _usersService
                .GetUserByCredentials(userCredentials.Username,userCredentials.Password);
            if(user == null)
            {
                return Unauthorized();
            }
            var key = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_config["Authentication:Key"]));
            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.UserId.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken
                (
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claims,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signingCredentials
                );
            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);
            
            return Ok(tokenToReturn);
        }

    }
}
