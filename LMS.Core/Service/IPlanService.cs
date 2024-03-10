using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface IPlanService
    {
        Task<List<Plan>> GetAllPlans();
        Task<Plan> GetPlanByID(int planID);
        Task<int> GetPlanCount();
        void CreatePlan(Plan plan);
        void UpdatePlan(Plan plan);
        void DeletePlan(int planID);
        Task<List<string>> FilterPlansByCourseID(int CourseID);
        Task<List<string>> FilterCoursesByPlanID(int PlanID);
        void AssignCoursesToPlan(int planID, int courseID);
        void DeleteCourseFromPlan(int planID, int courseID);

    }
}
