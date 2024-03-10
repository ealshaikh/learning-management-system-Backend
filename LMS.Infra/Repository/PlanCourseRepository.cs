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
    public class PlanCourseRepository : IPlanCourseRepository
    {

        private readonly IDbContext _dbContext;

        public PlanCourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePlanCourse(int planId, int courseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_PlanID", planId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_CourseID", courseId, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("PlanCoursePackage.CreatePlanCourse", parameters, commandType: CommandType.StoredProcedure);
        }

        public List<Plancourse> GetAllPlanCourses()
        {

            IEnumerable<Plancourse> result = _dbContext.Connection.Query<Plancourse>("PlanCoursePackage.GetAllPlanCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public async Task UpdatePlanCourse(int PlancourseId, Plancourse Plancourse)
        {
            var p = new DynamicParameters();
            p.Add("p_PlanID", PlancourseId, DbType.Int32, ParameterDirection.Input);
            p.Add("p_CourseID", PlancourseId, DbType.Int32, ParameterDirection.Input);


            await _dbContext.Connection.ExecuteAsync("PlanCoursePackage.UpdatePlanCourse", p, commandType: CommandType.StoredProcedure);
        }
        public async Task DeletePlanCourse(int Id)
        {


            var parameters = new DynamicParameters();
            parameters.Add("p_PlanCourseID", Id, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("PlanCoursePackage.DeletePlanCourse", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
