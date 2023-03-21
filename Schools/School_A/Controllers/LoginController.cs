using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private ILoginService _loginService;
        public LoginController(IConfiguration configuration, ILoginService loginService)
        {
            _configuration = configuration;
            _loginService = loginService;
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.Name == "Admin" && user.Password == "Pass")
                return Ok(_loginService.TokenGenerator());
            else return BadRequest("Invalid Credentials");
        }
    }
}