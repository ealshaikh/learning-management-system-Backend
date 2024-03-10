using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface ITeacherUserLoginRepository
    {
        Task CreateTeacherUserLogin(int teacherId, int roleId, string email, string password);

        Task UpdateTeacherUserLogin(Teacher teacher);
        Task DeleteTeacherUserLogin(int teacherUserLoginId);
        Task<int> GetTeacherUserLoginCount();
        Task<List<Teacheruserlogin>> GetAllTeacherUserLogin();
        Task<Teacheruserlogin> GetTeacherUserLogin(int teacherUserLoginId);
        Task UpdateTeacherUserLogin(int teacherUserLoginId, int teacherId, int roleId, string email, string password);
    }
}
