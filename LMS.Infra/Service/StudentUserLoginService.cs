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
    public class StudentUserLoginService : IStudentUserLoginService
    {
        private readonly IStudentUserLoginRepository _studentUserLoginRepository;

        public StudentUserLoginService(IStudentUserLoginRepository studentUserLoginRepository)
        {
            this._studentUserLoginRepository = studentUserLoginRepository;
        }

        public async Task<List<Studentuserlogin>> GetAllStudentLogins()
        {
            return await _studentUserLoginRepository.GetAllStudentLogins();
        }

        public async Task<int> GetStudentLoginCount()
        {
            return await _studentUserLoginRepository.GetStudentLoginCount();
        }

        public async void CreateStudentLogin(Studentuserlogin studentLogin)
        {
            _studentUserLoginRepository.CreateStudentLogin(studentLogin);
        }

        public async void UpdateStudentLogin(Studentuserlogin studentLogin)
        {
            _studentUserLoginRepository.UpdateStudentLogin(studentLogin);
        }

        public async void DeleteStudentLogin(int studentUserLoginID)
        {
            _studentUserLoginRepository.DeleteStudentLogin(studentUserLoginID);
        }

        public async Task<Studentuserlogin> GetStudentLoginByID(int studentUserLoginID)
        {
            return await _studentUserLoginRepository.GetStudentLoginByID(studentUserLoginID);
        }
    }
}
