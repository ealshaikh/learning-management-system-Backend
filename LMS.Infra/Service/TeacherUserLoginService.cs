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
    public class TeacherUserLoginService : ITeacherUserLoginService
    {
        private readonly ITeacherUserLoginRepository teacherUserLoginrepository;

        public TeacherUserLoginService(ITeacherUserLoginRepository teacherUserLoginrepository)
        {
            this.teacherUserLoginrepository = teacherUserLoginrepository;

        }
        public async Task CreateTeacherUserLogin(int teacherId, int roleId, string email, string password)
        {
            await teacherUserLoginrepository.CreateTeacherUserLogin(teacherId, roleId, email, password);
        }
        public async Task<List<Teacheruserlogin>> GetAllTeacherUserLogin()
        {
            return await teacherUserLoginrepository.GetAllTeacherUserLogin();
        }


        public async Task<Teacheruserlogin> GetTeacherUserLogin(int teacherUserLoginId)
        {
            return await teacherUserLoginrepository.GetTeacherUserLogin(teacherUserLoginId);
        }
        public async Task DeleteTeacherUserLogin(int teacherUserLoginId)
        {
            await teacherUserLoginrepository.DeleteTeacherUserLogin(teacherUserLoginId);
        }

        public async Task UpdateTeacherUserLogin(int teacherUserLoginId, int teacherId, int roleId, string email, string password)
        {
            await teacherUserLoginrepository.UpdateTeacherUserLogin(teacherUserLoginId, teacherId, roleId, email, password);
        }



    }

}
