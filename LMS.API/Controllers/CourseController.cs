using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService
        courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Route("UploadImage")]
        public Course UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";

            var fullPath = Path.Combine("E:\\Tahaluf\\Final_Project\\MindMaster_FrontEnd\\MindMaster\\src\\assets\\UploadImages", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Course course = new Course();
            course.Coverimage = fileName;
            return course;
        }

        [HttpGet]
        public List<Course> GetAllCourses()
        {
            return _courseService.GetAllCourses();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] string courseName, string coverImage)
        {
            try
            {
                // Validate the input model as needed

                await _courseService.CreateCourse(courseName, coverImage);

                return Ok("Course created successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }

        }
        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            try
            {
                // Assuming you have a method in your service to delete a course
                await _courseService.DeleteCourse(courseId);
                return Ok("Course deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] Course course)
        {
            try
            {
                // Assuming you have a method in your service to update a course
                await _courseService.UpdateCourse(courseId, course);
                return Ok("Course updated successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }


    }

}
