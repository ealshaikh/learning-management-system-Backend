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
    public class StudentAssessmentService : IStudentAssessmentService
    {
        private readonly IStudentAssessmentRepository _studentAssessmentRepository;

        public StudentAssessmentService(IStudentAssessmentRepository studentAssessmentRepository)
        {
            this._studentAssessmentRepository = studentAssessmentRepository;
        }

        public async void CreateStudentassessment(Studentassessment studentassessment)
        {
            _studentAssessmentRepository.CreateStudentassessment(studentassessment);
        }

        public async void DeleteStudentassessment(int id)
        {
            _studentAssessmentRepository.DeleteStudentassessment(id);
        }

        public async Task<List<Studentassessment>> GetAllStudentassessment()
        {
            return await _studentAssessmentRepository.GetAllStudentassessment();
        }

        public async Task<Studentassessment> GetStudentassessmentById(int id)
        {
            return await _studentAssessmentRepository.GetStudentassessmentById(id);
        }

        public async Task<int> GetStudentassessmentCount()
        {
            return await _studentAssessmentRepository.GetStudentassessmentCount();
        }

        public async void UpdateStudentassessment(Studentassessment studentassessment)
        {
            _studentAssessmentRepository.UpdateStudentassessment(studentassessment);
        }
    }

}
