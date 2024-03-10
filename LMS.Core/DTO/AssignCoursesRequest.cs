using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.DTO
{
    public class AssignCoursesRequest
    {
        public int PlanID { get; set; }
        public int CourseID { get; set; }
    }
}
