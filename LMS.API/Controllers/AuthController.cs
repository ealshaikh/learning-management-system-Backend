using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Studentlogin")]
        public IActionResult Login(Studentuserlogin studentuserlogin)
        {
            var token = _authService.Login(studentuserlogin);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }

        [HttpPost("Adminlogin")]
        public IActionResult AdminLogin(Adminuserlogin adminuserlogin) {
            var token = _authService.AdminLogin(adminuserlogin);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
    }
}
