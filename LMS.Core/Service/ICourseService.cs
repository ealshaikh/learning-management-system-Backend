using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        Task<Course> GetCourseById(int courseId);
        Task CreateCourse(string courseName, string coverImage);
        Task DeleteCourse(int courseId);
        Task UpdateCourse(int courseId, Course course);
    }
}
