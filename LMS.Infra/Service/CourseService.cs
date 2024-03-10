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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _course;
        public CourseService(ICourseRepository course)
        {
            _course = course;
        }
        public List<Course> GetAllCourses()
        {
            return _course.GetAllCourses();
        }
        public async Task<Course> GetCourseById(int courseId)
        {
            return _course.GetCourseById(courseId);
        }
        public async Task CreateCourse(string courseName, string coverImage)
        {
            await _course.CreateCourse(courseName, coverImage);
        }

        public async Task DeleteCourse(int courseId)
        {
            await _course.DeleteCourse(courseId);
        }

        public async Task UpdateCourse(int courseId, Course course)
        {
            await _course.UpdateCourse(courseId, course);
        }
    }

}
