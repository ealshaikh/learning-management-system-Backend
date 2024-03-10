using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface IStudentEnrollmentRepository
    {
        Task<List<Studentenrollment>> GetAllStudentEnrollments();
        Task<Studentenrollment> GetStudentEnrollmentByID(int enrollmentID);
        Task<int> GetStudentEnrollmentCount();
        Task CreateStudentEnrollment(Studentenrollment enrollment);
        Task UpdateStudentEnrollment(Studentenrollment enrollment);
        Task DeleteStudentEnrollment(int enrollmentID);
    }
}
