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
    public class StudentAssessmentRepository :IStudentAssessmentRepository
    {

        private readonly IDbContext _dbContext;

        public StudentAssessmentRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async void CreateStudentassessment(Studentassessment studentassessment)
        {
            var p = new DynamicParameters();
            p.Add("p_Comment", studentassessment.Comment, DbType.String, ParameterDirection.Input);
            p.Add("p_StudentID", studentassessment.Studentid, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.Execute("StudentAssessment_Package.CreateStudentAssessment", p, commandType: CommandType.StoredProcedure);

        }

        public async void DeleteStudentassessment(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("StudentAssessment_Package.DeleteStudentAssessment", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<Studentassessment>> GetAllStudentassessment()
        {
            var result = await _dbContext.Connection.QueryAsync<Studentassessment>("StudentAssessment_Package.GetAllStudentAssessments", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Studentassessment> GetStudentassessmentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Studentassessment>("StudentAssessment_Package.GetStudentAssessmentByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> GetStudentassessmentCount()
        {
            var p = new DynamicParameters();
            p.Add("CounterCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("StudentAssessment_Package.GetStudentAssessmentCount", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("CounterCount");
        }

        public async void UpdateStudentassessment(Studentassessment studentassessment)
        {
            var p = new DynamicParameters();
            p.Add("ID", studentassessment.Studentassessmentid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Comment", studentassessment.Comment, DbType.String, ParameterDirection.Input);
            p.Add("p_StudentID", studentassessment.Studentid, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.Execute("StudentAssessment_Package.UpdateStudentAssessment", p, commandType: CommandType.StoredProcedure);

        }
    }
}
