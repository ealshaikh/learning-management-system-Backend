using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentEnrollmentController : ControllerBase
    {
        private readonly IStudentEnrollmentService _studentEnrollmentService;

        public StudentEnrollmentController(IStudentEnrollmentService studentEnrollmentService)
        {
            this._studentEnrollmentService = studentEnrollmentService;
        }

        [HttpPost]
        [Route("CreateStudentEnrollment")]
        public async Task<IActionResult> CreateStudentEnrollment([FromBody] Studentenrollment enrollment)
        {
            try
            {
                await _studentEnrollmentService.CreateStudentEnrollment(enrollment);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteStudentEnrollment/{enrollmentID}")]
        public async Task<IActionResult> DeleteStudentEnrollment(int enrollmentID)
        {
            try
            {
                await _studentEnrollmentService.DeleteStudentEnrollment(enrollmentID);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllStudentEnrollments")]
        public async Task<ActionResult<List<Studentenrollment>>> GetAllStudentEnrollments()
        {
            try
            {
                var enrollments = await _studentEnrollmentService.GetAllStudentEnrollments();
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

      
        [HttpGet]
        [Route("GetStudentEnrollmentByID/{enrollmentID}")]
        public async Task<ActionResult<Studentenrollment>> GetStudentEnrollmentByID(int enrollmentID)
        {
            try
            {
                var enrollment = await _studentEnrollmentService.GetStudentEnrollmentByID(enrollmentID);
                if (enrollment == null)
                    return NotFound();
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetStudentEnrollmentCount")]
        public async Task<ActionResult<int>> GetStudentEnrollmentCount()
        {
            try
            {
                var count = await _studentEnrollmentService.GetStudentEnrollmentCount();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStudentEnrollment")]
        public async Task<IActionResult> UpdateStudentEnrollment([FromBody] Studentenrollment enrollment)
        {
            try
            {
                await _studentEnrollmentService.UpdateStudentEnrollment(enrollment);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
