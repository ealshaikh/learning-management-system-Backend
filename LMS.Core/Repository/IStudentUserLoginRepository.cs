using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface IStudentUserLoginRepository
    {
        Task<List<Studentuserlogin>> GetAllStudentLogins();
        Task<Studentuserlogin> GetStudentLoginByID(int studentUserLoginID);
        Task<int> GetStudentLoginCount();
        void CreateStudentLogin(Studentuserlogin studentLogin);
        void UpdateStudentLogin(Studentuserlogin studentLogin);
        void DeleteStudentLogin(int studentUserLoginID);
    }
}
