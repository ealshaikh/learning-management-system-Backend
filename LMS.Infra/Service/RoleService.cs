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
    public class RoleService : IRoleService

    {

        private readonly IRoleRepository _roleRepository ;

        public RoleService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }
        public async void CreateRole(Role role)
        {
            _roleRepository.CreateRole(role);
        }

        public async void DeleteRole(int ID)
        {
            _roleRepository.DeleteRole(ID);
        }

        public async Task<List<Role>> GetAllRolles()
        {
          return await _roleRepository.GetAllRolles();
        }

        public async Task<Role> GetRoleByID(int ID)
        {
         return await   _roleRepository.GetRoleByID(ID);
        }

        public async Task<int> GetRolesCount()
        {
            return await _roleRepository.GetRolesCount();
        }

        public async void UpdateRole(Role role)
        {
            _roleRepository.UpdateRole(role);
        }
    }
}
