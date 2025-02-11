using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        private IConfiguration _configuration;
        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _configuration = config;
        }

        [HttpPost]
        public IActionResult GetUserValidationResult(UserLogin userLogin)
        {
            var isValid = _loginService.ValidateUser(userLogin.UserName, userLogin.Password);
            if(isValid)
            {
                var token = GenerateJwtToken(string.Concat(userLogin.UserId,userLogin.UserName));
                userLogin.Token = token;
                return Ok(userLogin);

            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user),
                new Claim("role", "User")

            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
