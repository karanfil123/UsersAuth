using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersAuth.Models;

namespace UsersAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = Authenticatead(userLoginDto);

            if (user == null)
                return NotFound("User notfound!");

            var token = TokenCreate(user);
            return Ok(token);
        }

        private string TokenCreate(User user)
        {
            if (_jwtSettings == null) throw new Exception("Jwt key not null");

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credetials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Name,user.Fullname),
                new Claim(ClaimTypes.Role,user.Role),
            };

            var tokenHandler = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credetials);
            return new JwtSecurityTokenHandler().WriteToken(tokenHandler);
        }

        private User Authenticatead(UserLoginDto userLoginDto)
        {
            return Users.users.FirstOrDefault(x => x.Username == userLoginDto.Username && x.Password == userLoginDto.Password);
        }
    }
}
