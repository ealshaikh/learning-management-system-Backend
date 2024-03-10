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
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _dBContext;
        public CourseRepository(IDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task CreateCourse(string courseName, string coverImage)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CourseName", courseName, DbType.String, ParameterDirection.Input);

            parameters.Add("p_CoverImage", coverImage, DbType.String, ParameterDirection.Input);


            await _dBContext.Connection.ExecuteAsync("CoursePackage.CreateCourse", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteCourse(int courseId)
        {


            var parameters = new DynamicParameters();
            parameters.Add(" p_CourseID", courseId, DbType.Int32, ParameterDirection.Input);

            await _dBContext.Connection.ExecuteAsync(
                "CoursePackage.DeleteCourse",
                parameters,
                commandType: CommandType.StoredProcedure);
        }



        public List<Course> GetAllCourses()
        {

            IEnumerable<Course> result = _dBContext.Connection.Query<Course>("CoursePackage.GetAllCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public Course GetCourseById(int courseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CourseID", courseId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_CourseName", dbType: DbType.String, direction: ParameterDirection.Output, size: 255);

            parameters.Add("p_CoverImage", dbType: DbType.String, direction: ParameterDirection.Output, size: 240);


            _dBContext.Connection.Execute("CoursePackage.GetCourseById", parameters, commandType: CommandType.StoredProcedure);

            // Retrieve output parameters
            string courseName = parameters.Get<string>("p_CourseName");

            string coverImage = parameters.Get<string>("p_CoverImage");


            // Create and return a Course object
            return new Course
            {
                Courseid = courseId,
                Coursename = courseName,


                Coverimage = coverImage,

                // Exclude CourseDescription from here
                // Add other properties as needed
            };

        }



        public async Task UpdateCourse(int courseId, Course course)
        {
            var p = new DynamicParameters();
            p.Add("p_CourseID", courseId, DbType.Int32, ParameterDirection.Input);
            p.Add("p_CourseName", course.Coursename, DbType.String, ParameterDirection.Input);

            p.Add("p_CoverImage", course.Coverimage, DbType.String, ParameterDirection.Input);


            await _dBContext.Connection.ExecuteAsync("CoursePackage.UpdateCourse", p, commandType: CommandType.StoredProcedure);
        }
    }

}
