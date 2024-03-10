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
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public void CreateExam(int ExamId, DateTime examDate, DateTime startTime, DateTime endTime, string mark, string subject, int courseId)
        {
            _examRepository.CreateExam(ExamId, examDate, startTime, endTime, mark, subject, courseId);
        }
        public Exam GetExamById(int examId)
        {
            return _examRepository.GetExamById(examId);
        }
        public List<Exam> GetAllExams()
        {
            return _examRepository.GetAllExams();
        }

        void IExamService.UpdateExam(Exam exam)
        {
            _examRepository.UpdateExam(exam);
        }
        public async Task DeleteExam(int examId)
        {
            await _examRepository.DeleteExam(examId);
        }
    }

}
