using LMS.Core.Data;
using LMS.Core.Service;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAssessmentController : ControllerBase
    {

        private readonly IStudentAssessmentService _studentAssessmentService;

        public StudentAssessmentController(IStudentAssessmentService studentAssessmentService)
        {
            _studentAssessmentService = studentAssessmentService;
        }


        [HttpGet("GetAllStudentAssessment")]
        public async Task<ActionResult<List<Studentassessment>>> GetAllStudentAssessment()
        {
            try
            {
                var UserSectio = await _studentAssessmentService.GetAllStudentassessment();
                return Ok(UserSectio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetStudentassessmentByID/{id}")]
        public async Task<ActionResult<Studentassessment>> GetStudentassessmentByID(int id)
        {
            try
            {
                var UserSection = await _studentAssessmentService.GetStudentassessmentById(id);
                if (UserSection == null)
                {
                    return NotFound($"Studentassessment with ID {id} not found.");
                }

                return Ok(UserSection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetStudentassessmentCount")]
        public async Task<ActionResult<int>> GetStudentassessmentCount()
        {
            try
            {
                var UserSectioncount = await _studentAssessmentService.GetStudentassessmentCount();
                return Ok(UserSectioncount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateStudentassessmen")]
        public ActionResult CreateUserSection([FromBody] Studentassessment studentassessment)
        {
            try
            {
                _studentAssessmentService.CreateStudentassessment(studentassessment);
                return CreatedAtAction(nameof(GetStudentassessmentByID), new { id = studentassessment.Studentassessmentid }, studentassessment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateStudentassessment")]
        public async void UpdateStudentassessment(Studentassessment studentassessment)
        {
            _studentAssessmentService.UpdateStudentassessment(studentassessment);
        }

        [HttpDelete("DeleteStudentAssesment/{id}")]
        public async void DeleteStudentAssesment(int id)
        {
            _studentAssessmentService.DeleteStudentassessment(id);
        }

    }
}
