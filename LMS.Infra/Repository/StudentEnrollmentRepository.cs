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
    public class StudentEnrollmentRepository :IStudentEnrollmentRepository
    {
        private readonly IDbContext _dbContext;

        public StudentEnrollmentRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Studentenrollment>> GetAllStudentEnrollments()
        {
            var result = await _dbContext.Connection.QueryAsync<Studentenrollment>(
                "StudentEnrollment_Package.GetAllEnrollmentedStudent",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public async Task<Studentenrollment> GetStudentEnrollmentByID(int enrollmentID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_EnrollmentID", enrollmentID, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Studentenrollment>(
                "StudentEnrollment_Package.GetStudentEnrollmentByID",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public async Task<int> GetStudentEnrollmentCount()
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_EnrollmentCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "StudentEnrollment_Package.GetStudentEnrollmentCount",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("p_EnrollmentCount");
        }


        public async Task CreateStudentEnrollment(Studentenrollment enrollment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_StudentID", enrollment.Studentid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_PlanID", enrollment.Planid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_EnrollmentDate", enrollment.Enrollmentdate, DbType.Date, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "StudentEnrollment_Package.CreateStudentEnrollment",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task UpdateStudentEnrollment(Studentenrollment enrollment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_EnrollmentID", enrollment.Enrollmentid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_StudentID", enrollment.Studentid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_PlanID", enrollment.Planid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_EnrollmentDate", enrollment.Enrollmentdate, DbType.Date, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "StudentEnrollment_Package.UpdateStudentEnrollment",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteStudentEnrollment(int enrollmentID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_EnrollmentID", enrollmentID, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "StudentEnrollment_Package.DeleteStudentEnrollment",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
