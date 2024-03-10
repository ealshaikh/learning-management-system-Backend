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
    public class PlanCourseService : IPlanCourseService
    {
        private readonly IPlanCourseRepository _planCourseRepository;

        public PlanCourseService(IPlanCourseRepository planCourseRepository)
        {
            _planCourseRepository = planCourseRepository;
        }

        public void CreatePlanCourse(int planId, int courseId)
        {
            _planCourseRepository.CreatePlanCourse(planId, courseId);
        }

        public List<Plancourse> GetAllPlanCourses()
        {
            return _planCourseRepository.GetAllPlanCourses();
        }
        public async Task UpdatePlanCourse(int PlancourseId, Plancourse Plancourse)
        {
            await _planCourseRepository.UpdatePlanCourse(PlancourseId, Plancourse);
        }
        public async Task DeletePlanCourse(int PlancourseId)
        {
            await _planCourseRepository.DeletePlanCourse(PlancourseId);
        }
    }

}
