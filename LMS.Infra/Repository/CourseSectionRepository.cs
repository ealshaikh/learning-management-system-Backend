using Dapper;
using LMS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{

    public class CourseSectionRepository : ICourseSectionRepository
    {
        private readonly IDbContext _dbContext;

        public CourseSectionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCourseSection(int courseId, int sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CourseID", courseId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_SectionID", sectionId, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("YourPackage.CreateCourseSection", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
