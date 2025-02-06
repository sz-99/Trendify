using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult GetUserValidationResult( UserLogin userLogin)
        {
            var isValid = _loginService.ValidateUser(userLogin.UserName, userLogin.Password);
            if(isValid)
            {
                return Ok(userLogin);
            }
            return Unauthorized();
        }
    }
}
