using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAllAdmins();

        Task<Admin> GetAdminByID(int ID);

        Task<int> GetAdminCount();

        void CreateAdmin(Admin admin);
        void UpdateAdmin(Admin admin);


        void DeleteAdmin(int ID);

    }
}
