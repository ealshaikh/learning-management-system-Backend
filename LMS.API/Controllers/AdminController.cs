using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMS.Infra.Service;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            this._adminService = adminService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        [Route("GetAllAdmins")]
        public async Task<List<Admin>> GetAllAdminss()
        {
            return await _adminService.GetAllAdmins();
        }

        [HttpGet]
        [Route("GetAdminById/{id}")]
        public async Task<Admin> GetAdminById(int id)
        {
            return await _adminService.GetAdminByID(id);
        }

        [HttpGet]
        [Route("GetAdminCount")]
        public async Task<int> GetAdminsCount()
        {
            return await _adminService.GetAdminCount();
        }


        [HttpPost]
        public async void CreateAdmin(Admin admin)
        {
            _adminService.CreateAdmin(admin);
        }

        [HttpDelete(" DeleteAdmin/{id}")]
        public async void DeleteAdmin(int id)
        {
            _adminService.DeleteAdmin(id);
        }

        [HttpPut]
        public async void UpdateAdmin(Admin admin)
        {
            _adminService.UpdateAdmin(admin);
        }

    }
}
