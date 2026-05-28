using Crn_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crn_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            if (user.Username == "admin" && user.Password == "1234")
            {
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("ThisIsMyVeryStrongSecretKeyForJwtAuthentication12345")
                );

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    },
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(jwt);
            }

            return Unauthorized("Invalid credentials");
        }
    }
}