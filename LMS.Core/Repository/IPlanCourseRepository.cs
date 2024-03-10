using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface IPlanCourseRepository
    {
        void CreatePlanCourse(int planId, int courseId);
        List<Plancourse> GetAllPlanCourses();
        Task UpdatePlanCourse(int PlancourseId, Plancourse Plancourse);
        Task DeletePlanCourse(int Id);

    }
}
