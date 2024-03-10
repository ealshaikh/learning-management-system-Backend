using Dapper;
using Dapper.Oracle;
using LMS.Core.Data;
using LMS.Core.Repository;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository
{
    public class PlanRepository : IPlanRepository
    {
        private readonly IDbContext _dbContext;

        public PlanRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Plan>> GetAllPlans()
        {
            var result = await _dbContext.Connection.QueryAsync<Plan>("Plan_Package.GetAllPlans", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Plan> GetPlanByID(int planID)
        {
            var p = new DynamicParameters();
            p.Add("ID", planID, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Plan>("Plan_Package.GetPlanByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> GetPlanCount()
        {
            var p = new DynamicParameters();
            p.Add("PlanCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Plan_Package.GetPlanCount", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("PlanCount");
        }

        public void CreatePlan(Plan plan)
        {
            var p = new DynamicParameters();
            p.Add("PlanName", plan.Planname, DbType.String, ParameterDirection.Input);
            p.Add("PlanDescription", plan.Plandescription, DbType.String, ParameterDirection.Input);
            p.Add("CoverImage", plan.Coverimage, DbType.String, ParameterDirection.Input);
            p.Add("PlanPrice", plan.Planprice, DbType.Int32, ParameterDirection.Input);
            p.Add("StartDate", plan.Startdate, DbType.Date, ParameterDirection.Input);
            p.Add("EndDate", plan.Enddate, DbType.Date, ParameterDirection.Input);

            _dbContext.Connection.Execute("Plan_Package.CreatePlan", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdatePlan(Plan plan)
        {
            var p = new DynamicParameters();
            p.Add("p_PlanID", plan.Planid, DbType.Int32, ParameterDirection.Input);

            // Check if the fields are not null before adding them to the parameters
            if (plan.Planname != null)
                p.Add("p_NewPlanName", plan.Planname, DbType.String, ParameterDirection.Input);

            if (plan.Plandescription != null)
                p.Add("p_NewPlanDesc", plan.Plandescription, DbType.String, ParameterDirection.Input);

            if (plan.Coverimage != null)
                p.Add("p_NewCoverImage", plan.Coverimage, DbType.String, ParameterDirection.Input);

            if (plan.Planprice != null)
                p.Add("p_NewPlanPrice", plan.Planprice, DbType.Int32, ParameterDirection.Input);

            if (plan.Startdate != null)
                p.Add("P_StartDate", plan.Startdate, DbType.Date, ParameterDirection.Input);

            if (plan.Enddate != null)
                p.Add("P_EndDate", plan.Enddate, DbType.Date, ParameterDirection.Input);

            _dbContext.Connection.Execute("Plan_Package.UpdatePlan", p, commandType: CommandType.StoredProcedure);
        }


        public void DeletePlan(int planID)
        {
            var p = new DynamicParameters();
            p.Add("ID", planID, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("Plan_Package.DeletePlan", p, commandType: CommandType.StoredProcedure);
        }




        public void AssignCoursesToPlan(int planID, int courseID)
        {
            var p = new DynamicParameters();
            p.Add("p_PlanID", planID, DbType.Int32, ParameterDirection.Input);
            p.Add("p_CourseID", courseID, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("Plan_Package.AssignCoursesToPlan", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCourseFromPlan(int planID, int courseID)
        {
            var p = new DynamicParameters();
            p.Add("p_PlanID", planID, DbType.Int32, ParameterDirection.Input);
            p.Add("p_CourseID", courseID, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("Plan_Package.DeleteCourseFromPlan", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<string>> FilterPlansByCourseID(int courseID)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("p_course_id", courseID, OracleMappingType.Int32, ParameterDirection.Input);
                p.Add("p_plan_names", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = await _dbContext.Connection.QueryAsync<string>(
                    "Plan_Package.FilterPlansByCourseID",
                    p,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in FilterPlansByCourseID for course ID {courseID}: {ex.Message}");
                throw;
            }
        }

        public async Task<List<string>> FilterCoursesByPlanID(int planID)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("p_plan_id", planID, OracleMappingType.Int32, ParameterDirection.Input);
                p.Add("p_course_names", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = await _dbContext.Connection.QueryAsync<string>(
                    "Plan_Package.FilterCoursesByPlanID", p, commandType: CommandType.StoredProcedure
                );

                // Check if the result is not null before converting it to a list
                return result?.ToList() ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in FilterCoursesByPlanID for PlanID {planID}: {ex.Message}");
                throw;
            }
        }

    



    }
}
