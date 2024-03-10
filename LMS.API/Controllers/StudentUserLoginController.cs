using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentUserLoginController : ControllerBase
    {
        private readonly IStudentUserLoginService _studentUserLoginService;

        public StudentUserLoginController(IStudentUserLoginService studentUserLoginService)
        {
            _studentUserLoginService = studentUserLoginService;
        }


        [HttpGet]
        [Route("GetAllStudentLogins")]
        public async Task<List<Studentuserlogin>> GetAllStudentLogins()
        {
            return await _studentUserLoginService.GetAllStudentLogins();
        }

        [HttpGet]
        [Route("GetStudentLoginById/{id}")]
        public async Task<Studentuserlogin> GetStudentLoginById(int id)
        {
            return await _studentUserLoginService.GetStudentLoginByID(id);
        }

        [HttpGet]
        [Route("GetStudentLoginsCount")]
        public async Task<int> GetStudentLoginsCount()
        {
            return await _studentUserLoginService.GetStudentLoginCount();
        }

        [HttpPost]
        [Route("CreateStudentLogin")]
        public async void CreateStudentLogin(Studentuserlogin studentLogin)
        {
            _studentUserLoginService.CreateStudentLogin(studentLogin);
        }

        [HttpPut]
        [Route("UpdateStudentLogin")]
        public async void UpdateStudentLogin(Studentuserlogin studentLogin)
        {
            _studentUserLoginService.UpdateStudentLogin(studentLogin);
        }

        [HttpDelete("DeleteStudentLogin/{id}")]
        public async void DeleteStudentLogin(int id)
        {
            _studentUserLoginService.DeleteStudentLogin(id);
        }
    }
}
