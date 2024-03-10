using Dapper;
using LMS.Core.Data;
using LMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly IDbContext _dBContext;

        public ExamRepository(IDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void CreateExam(int ExamId, DateTime examDate, DateTime startTime, DateTime endTime, string mark, string subject, int courseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ExamID", ExamId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_ExamDate", examDate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_StartTime", startTime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("p_EndTime", endTime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("p_Mark", mark, DbType.String, ParameterDirection.Input);
            parameters.Add("p_Subject", subject, DbType.String, ParameterDirection.Input);
            parameters.Add("p_CourseID", courseId, DbType.Int32, ParameterDirection.Input);

            _dBContext.Connection.Execute("ExamPackage.CreateExam", parameters, commandType: CommandType.StoredProcedure);
        }
        public Exam GetExamById(int examId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ExamID", examId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_ExamDate", dbType: DbType.Date, direction: ParameterDirection.Output);
            parameters.Add("p_StartTime", dbType: DbType.DateTime, direction: ParameterDirection.Output);
            parameters.Add("p_EndTime", dbType: DbType.DateTime, direction: ParameterDirection.Output);
            parameters.Add("p_Mark", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameters.Add("p_Subject", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
            parameters.Add("p_CourseID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _dBContext.Connection.Execute("ExamPackage.GetExamById", parameters, commandType: CommandType.StoredProcedure);

            // Retrieve output parameters
            int ExamId = parameters.Get<int>("p_ExamID");
            DateTime examDate = parameters.Get<DateTime>("p_ExamDate");
            DateTime startTime = parameters.Get<DateTime>("p_StartTime");
            DateTime endTime = parameters.Get<DateTime>("p_EndTime");
            string mark = parameters.Get<string>("p_Mark");
            string subject = parameters.Get<string>("p_Subject");
            int courseID = parameters.Get<int>("p_CourseID");

            // Create and return an Exam object
            return new Exam
            {
                Examid = examId,
                Examdate = examDate,
                Starttime = startTime,
                Endtime = endTime,
                Mark = mark,
                Subject = subject,
                Courseid = courseID
                // Add other properties as needed
            };
        }
        public List<Exam> GetAllExams()
        {

            IEnumerable<Exam> result = _dBContext.Connection.Query<Exam>("ExamPackage.GetAllExams", commandType: CommandType.StoredProcedure);
            return result.ToList();


        }
        public void UpdateExam(Exam exam)
        {
            using (var connection = _dBContext.Connection)
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("p_ExamID", exam.Examid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_ExamDate", exam.Examdate, DbType.Date, ParameterDirection.Input);
                parameters.Add("p_StartTime", exam.Starttime, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("p_EndTime", exam.Endtime, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("p_Mark", exam.Mark, DbType.String, ParameterDirection.Input);
                parameters.Add("p_Subject", exam.Subject, DbType.String, ParameterDirection.Input);
                parameters.Add("p_CourseID", exam.Courseid, DbType.Int32, ParameterDirection.Input);
                connection.Execute("ExamPackage.UpdateExam", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task DeleteExam(int examId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ExamID", examId, DbType.Int32, ParameterDirection.Input);

            await _dBContext.Connection.ExecuteAsync("ExamPackage.DeleteExam", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
