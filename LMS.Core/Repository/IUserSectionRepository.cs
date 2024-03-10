using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface IUserSectionRepository
    {
        Task<List<Usersection>> GetAllUserInSections();

        Task<Usersection> GetUserInSectionById(int id);

        Task<int> GetUserInSectionCount();

        void CreateUserInSection (Usersection usersection);

        void UpdateUserInSection (Usersection usersection);
        
        void DeleteUserInSection (int id);
    }
}
