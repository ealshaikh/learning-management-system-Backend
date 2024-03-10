using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface ICourseSectionRepository
    {
        Task CreateCourseSection(int courseId, int sectionId);
    }
}
