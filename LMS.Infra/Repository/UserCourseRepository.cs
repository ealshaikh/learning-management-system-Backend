using Dapper;
using Dapper.Oracle;
using LMS.Core.Data;
using Oracle.ManagedDataAccess.Client;
using LMS.Core.Repository;
using Oracle.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.DTO;
namespace LMS.Infra.Repository
{
    public class UserCourseRepository : IUserCourseRepository
    {

        private readonly IDbContext _dbContext;

        public UserCourseRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async void CreateUsercourse(Usercourse usercourse)
        {
            var p = new DynamicParameters();
            p.Add("p_CourseID", usercourse.Courseid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StudentID", usercourse.Studentid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_ExamID", usercourse.Examid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StudentGrade", usercourse.Studentgrade, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Status", usercourse.Status, DbType.String, ParameterDirection.Input);


            _dbContext.Connection.Execute("UserCourse_Package.CreateUserCourse", p, commandType: CommandType.StoredProcedure);

        }

        public async void DeleteUsercourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserCourseID", id, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("UserCourse_Package.DeleteUserCourse", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<CourseSectionInfo>> FilterCourseSection(int courseid)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("p_courseID", courseid, OracleMappingType.Int32, ParameterDirection.Input);
                p.Add("p_sections", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = await _dbContext.Connection.QueryAsync<CourseSectionInfo>("UserCourse_Package.FilterCourseSection", p, commandType: CommandType.StoredProcedure);

                // Check if the result is not null before converting it to a list
                return result?.ToList() ?? new List<CourseSectionInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in FilterCourseSection for CourseID {courseid}: {ex.Message}");
                throw;
            }
        }

        public async Task<List<CourseInfo>> FilterSectionCourses(int sectionid)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("p_sectionID", sectionid, OracleMappingType.Int32, ParameterDirection.Input);
                p.Add("p_courses", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = await _dbContext.Connection.QueryAsync<CourseInfo>("UserCourse_Package.FilterSectionCourses", p, commandType: CommandType.StoredProcedure);

                // Check if the result is not null before converting it to a list
                return result?.ToList() ?? new List<CourseInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in FilterSectionCourses for SectionID {sectionid}: {ex.Message}");
                throw;
            }
        }


        public async Task<List<Usercourse>> GetAllUsercourse()
        {
            var result = await _dbContext.Connection.QueryAsync<Usercourse>("UserCourse_Package.GetAllUserCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public async Task<Usercourse> GetUsercourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserCourseID", id, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Usercourse>("UserCourse_Package.GetUserCourseByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async Task<int> GetUsercourseCount()
        {
            var p = new DynamicParameters();
            p.Add("p_UserCourseCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("UserCourse_Package.GetUserCourseCount", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("p_UserCourseCount");

        }

        public async void UpdateUsercourse(Usercourse usercourse)
        {
            var p = new DynamicParameters();
            p.Add("p_UserCourseID", usercourse.Usercourseid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_CourseID", usercourse.Courseid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StudentID", usercourse.Studentid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_ExamID", usercourse.Examid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_StudentGrade", usercourse.Studentgrade, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Status", usercourse.Status, DbType.String, ParameterDirection.Input);


            _dbContext.Connection.Execute("UserCourse_Package.UpdateUserCourse", p, commandType: CommandType.StoredProcedure);


        }
    }
}
