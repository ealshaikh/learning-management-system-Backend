using LMS.Core.Data;
using LMS.Core.Repository;
using LMS.Core.Service;
using LMS.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class AdminUserLoginService : IAdminUserloginService

    {

        private readonly IAdminUserloginRepository _adminUserloginRepository;

        public AdminUserLoginService(IAdminUserloginRepository adminUserloginRepository)
        {
            _adminUserloginRepository = adminUserloginRepository;
        }

        public async void CreateAdminUserlogin(Adminuserlogin admin)
        {
            _adminUserloginRepository.CreateAdminUserlogin(admin);
        }

        public async void DeleteAdminUserlogin(int ID)
        {
            _adminUserloginRepository.DeleteAdminUserlogin(ID);
        }

        public async Task<Adminuserlogin> GetAdminUserloginByID(int ID)
        {
           return await _adminUserloginRepository.GetAdminUserloginByID(ID);
        }

        public async Task<int> GetAdminUserloginCount()
        {
            return await _adminUserloginRepository.GetAdminUserloginCount();
        }

        public async Task<List<Adminuserlogin>> GetAllAdminUserLogin()
        {
            return await _adminUserloginRepository.GetAllAdminUserLogin();
        }

        public async void UpdateAdminUserlogin(Adminuserlogin admin)
        {
          _adminUserloginRepository.UpdateAdminUserlogin(admin);
        }
    }
}
