using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IExamService
    {
        void CreateExam(int ExamId, DateTime examDate, DateTime startTime, DateTime endTime, string mark, string subject, int courseId);
        Exam GetExamById(int examId);
        List<Exam> GetAllExams();
        void UpdateExam(Exam exam);
        Task DeleteExam(int examId);
    }
}
