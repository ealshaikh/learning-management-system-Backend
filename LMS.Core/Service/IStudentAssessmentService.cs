using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IStudentAssessmentService
    {
        Task<List<Studentassessment>> GetAllStudentassessment();

        Task<Studentassessment> GetStudentassessmentById(int id);

        Task<int> GetStudentassessmentCount();

        void CreateStudentassessment(Studentassessment studentassessment);

        void UpdateStudentassessment(Studentassessment studentassessment);

        void DeleteStudentassessment(int id);

    }
}
