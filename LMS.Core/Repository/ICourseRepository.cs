using LMS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository
{
    public interface ICourseRepository
    {

        List<Course> GetAllCourses();
        Task CreateCourse(string courseName, string coverImage);
        Task DeleteCourse(int courseId);
        Task UpdateCourse(int courseId, Course course);
        Course GetCourseById(int courseId);



    }
}
