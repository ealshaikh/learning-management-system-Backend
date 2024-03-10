using AutoMapper;
using LMS.Core.Data;
using LMS.Core.Service;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserloginController : ControllerBase
    {
        private readonly IAdminUserloginService _adminUserloginService;
        public AdminUserloginController(IAdminUserloginService adminUserloginService)
        {
            this._adminUserloginService = adminUserloginService;

        }

        [HttpGet]
        [Route("GetAllAdminUserlogins")]
        public async Task<List<Adminuserlogin>> GetAllAdmins()
        {
            return await _adminUserloginService.GetAllAdminUserLogin();
        }

        [HttpGet]
        [Route("GetAdminUserloginById/{id}")]
        public async Task<Adminuserlogin> GetAdminUserloginById(int id)
        {
            return await _adminUserloginService.GetAdminUserloginByID(id);
        }

        [HttpGet]
        [Route("GetAdminUserloginCount")]
        public async Task<int> GetAdminUserloginCount()
        {
            return await _adminUserloginService.GetAdminUserloginCount();
        }


        [HttpPost]
        public async void CreateAdminUserlogin(Adminuserlogin admin)
        {
            _adminUserloginService.CreateAdminUserlogin(admin);
        }

        [HttpDelete(" DeleteAdminUserlogin/{id}")]
        public async void DeleteAdminUserlogin(int id)
        {
            _adminUserloginService.DeleteAdminUserlogin(id);
        }

        [HttpPut]
        public async void UpdateAdminUserlogin(Adminuserlogin admin)
        {
            _adminUserloginService.UpdateAdminUserlogin(admin);
        }
    }
}
