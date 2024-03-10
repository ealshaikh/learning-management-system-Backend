using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolles();

        Task<Role> GetRoleByID(int ID);

        Task<int> GetRolesCount();

        void CreateRole(Role role);

        void UpdateRole(Role role);

        void DeleteRole(int ID);
    }
}
