using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface ITeacherUserLoginService
    {
        Task CreateTeacherUserLogin(int teacherId, int roleId, string email, string password);
        Task<List<Teacheruserlogin>> GetAllTeacherUserLogin();
        Task<Teacheruserlogin> GetTeacherUserLogin(int teacherUserLoginId);
        Task DeleteTeacherUserLogin(int teacherUserLoginId);
        Task UpdateTeacherUserLogin(int teacherUserLoginId, int teacherId, int roleId, string email, string password);

    }
}
