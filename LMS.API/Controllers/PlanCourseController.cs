using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanCourseController : ControllerBase
    {
        private readonly IPlanCourseService _planCourseService;

        public PlanCourseController(IPlanCourseService planCourseService)
        {
            _planCourseService = planCourseService;
        }

        [HttpPost]
        public IActionResult CreatePlanCourse([FromBody] int planId, int courseId)
        {
            try
            {
                _planCourseService.CreatePlanCourse(planId, courseId);
                return Ok("PlanCourse created successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public List<Plancourse> GetAllPlanCourses()
        {
            return _planCourseService.GetAllPlanCourses();
        }

        [HttpPut("{PlancourseId}")]
        public async Task<IActionResult> UpdateCourse(int PlancourseId, [FromBody] Plancourse Plancourse)
        {
            try
            {

                await _planCourseService.UpdatePlanCourse(PlancourseId, Plancourse);
                return Ok("PlanCourse updated successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePlanCourse(int Id)
        {
            try
            {
                // Assuming you have a method in your service to delete a course
                await _planCourseService.DeletePlanCourse(Id);
                return Ok("PlanCourse deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
