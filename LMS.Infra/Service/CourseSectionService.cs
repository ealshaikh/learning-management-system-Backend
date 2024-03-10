using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class CourseSectionService : ICourseSectionService
    {
        private readonly ICourseSectionRepository _courseSectionRepository;

        public CourseSectionService(ICourseSectionRepository courseSectionRepository)
        {
            _courseSectionRepository = courseSectionRepository;
        }


        public async Task CreateCourseSection(int courseId, int sectionId)
        {
            await _courseSectionRepository.CreateCourseSection(courseId, sectionId);
        }
    }
}
