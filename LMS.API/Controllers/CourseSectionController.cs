using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSectionController : ControllerBase
    {

        private readonly ICourseSectionService _courseSectionService;

        public CourseSectionController(ICourseSectionService courseSectionService)
        {
            _courseSectionService = courseSectionService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourseSection([FromBody] int courseId, int sectionId)
        {
            try
            {
                // Validate the input model as needed
                await _courseSectionService.CreateCourseSection(courseId, sectionId);

                return Ok("Course section created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
