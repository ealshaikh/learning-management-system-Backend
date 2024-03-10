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
    public class StudentEnrollmentService : IStudentEnrollmentService
    {
        private readonly IStudentEnrollmentRepository _studentEnrollmentRepository;

        public StudentEnrollmentService(IStudentEnrollmentRepository studentEnrollmentRepository)
        {
            this._studentEnrollmentRepository = studentEnrollmentRepository;
        }

       public async Task CreateStudentEnrollment(Studentenrollment enrollment)
        {
            await _studentEnrollmentRepository.CreateStudentEnrollment(enrollment);
        }

        public async Task DeleteStudentEnrollment(int enrollmentID)
        {
            await _studentEnrollmentRepository.DeleteStudentEnrollment(enrollmentID);
        }

        public async Task<List<Studentenrollment>> GetAllStudentEnrollments()
        {
            return await _studentEnrollmentRepository.GetAllStudentEnrollments();
        }

       

        public async Task<Studentenrollment> GetStudentEnrollmentByID(int enrollmentID)
        {
            return await _studentEnrollmentRepository.GetStudentEnrollmentByID(enrollmentID);
        }

        public async Task<int> GetStudentEnrollmentCount()
        {
            return await _studentEnrollmentRepository.GetStudentEnrollmentCount();
        }

        public async Task UpdateStudentEnrollment(Studentenrollment enrollment)
        {
            await _studentEnrollmentRepository.UpdateStudentEnrollment(enrollment);
        }
    }
}
