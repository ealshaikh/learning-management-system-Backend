using LMS.Core.Data;
using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository) 
        {
            _adminRepository = adminRepository; 
        }

        public async void CreateAdmin(Admin admin)
        {
            _adminRepository.CreateAdmin(admin);
        }

        public async void UpdateAdmin(Admin admin)
        {
            _adminRepository.UpdateAdmin(admin);
        }

        public async void DeleteAdmin(int ID)
        {
            _adminRepository.DeleteAdmin(ID);
        }

        public async Task<Admin> GetAdminByID(int ID)
        {
            return await _adminRepository.GetAdminByID(ID);
        }

        public async Task<int> GetAdminCount()
        {
            return await _adminRepository.GetAdminCount();
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            return await _adminRepository.GetAllAdmins();
        }



    }
}
