using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IAdminUserloginService
    {
        Task<List<Adminuserlogin>> GetAllAdminUserLogin();

        Task<Adminuserlogin> GetAdminUserloginByID(int ID);

        Task<int> GetAdminUserloginCount();

        void CreateAdminUserlogin(Adminuserlogin admin);
        void UpdateAdminUserlogin(Adminuserlogin admin);

        void DeleteAdminUserlogin(int ID);
    }
}
