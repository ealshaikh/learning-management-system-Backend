using LMS.Core.Data;
using LMS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface IUserCourseRepository
    {
        Task<List<Usercourse>> GetAllUsercourse();

        Task<Usercourse> GetUsercourseById(int id);

        Task<int> GetUsercourseCount();

        void CreateUsercourse(Usercourse usercourse);

        void UpdateUsercourse(Usercourse usercourse);

        void DeleteUsercourse(int id);

        Task<List<CourseSectionInfo>> FilterCourseSection(int courseid);
        Task<List<CourseInfo>> FilterSectionCourses(int sectionid);
    }
}
