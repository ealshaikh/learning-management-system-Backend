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
    public class UserSectionService : IUserSectionService
    {
        private readonly IUserSectionRepository _userSection;

        public  UserSectionService(IUserSectionRepository userSection)
        {
            this._userSection = userSection;
        }

        public async void CreateUserInSection(Usersection usersection)
        {
            _userSection.CreateUserInSection(usersection);
        }

        public async void DeleteUserInSection(int id)
        {
            _userSection.DeleteUserInSection(id);
        }

        public async Task<List<Usersection>> GetAllUserInSections()
        {
            return await _userSection.GetAllUserInSections();
        }

        public async Task<Usersection> GetUserInSectionById(int id)
        {
            return await _userSection.GetUserInSectionById(id);
        }

        public async Task<int> GetUserInSectionCount()
        {
            return await _userSection.GetUserInSectionCount();
        }

        public async void UpdateUserInSection(Usersection usersection)
        {
            _userSection.UpdateUserInSection(usersection);
        }
    }
}
