using LMS.Core.Data;
using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class PlanService : IPlanService
    {    
        private readonly IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            this._planRepository = planRepository;
        }

        public async Task<List<Plan>> GetAllPlans()
        {
            return await _planRepository.GetAllPlans();
        }

        public async Task<Plan> GetPlanByID(int planID)
        {
            return await _planRepository.GetPlanByID(planID);
        }

        public async Task<int> GetPlanCount()
        {
            return await _planRepository.GetPlanCount();
        }

        public void CreatePlan(Plan plan)
        {
            _planRepository.CreatePlan(plan);
        }

        public void UpdatePlan(Plan plan)
        {
            _planRepository.UpdatePlan(plan);
        }

        public void DeletePlan(int planID)
        {
            _planRepository.DeletePlan(planID);
        }

        public async Task<List<string>> FilterPlansByCourseID(int CourseID)
        {
            return await _planRepository.FilterPlansByCourseID(CourseID);
        }

        public async Task<List<string>> FilterCoursesByPlanID(int PlanID)
        {
            return await _planRepository.FilterCoursesByPlanID(PlanID);

        }
        public void AssignCoursesToPlan(int planID, int courseID)
        {
            _planRepository.AssignCoursesToPlan(planID, courseID);
        }

        public void DeleteCourseFromPlan(int planID, int courseID)
        {
            _planRepository.DeleteCourseFromPlan(planID, courseID);
        }

       
    }
}
