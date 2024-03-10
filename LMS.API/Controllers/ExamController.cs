using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {


        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost]
        public IActionResult CreateExam([FromBody] int examId, DateTime examDate, DateTime startTime, DateTime endTime, string mark, string subject, int courseId)
        {
            try
            {
                // Validate the input model as needed

                _examService.CreateExam(examId, examDate, startTime, endTime, mark, subject, courseId);

                return Ok("Exam created successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{examId}")]
        public IActionResult GetExamById(int examId)
        {
            try
            {
                var exam = _examService.GetExamById(examId);

                if (exam != null)
                {
                    return Ok(exam);
                }
                else
                {
                    return NotFound($"Exam with ID {examId} not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet]
        public List<Exam> GetAllExams()
        {
            return _examService.GetAllExams();
        }
        [HttpPut("{examId}")]
        public IActionResult UpdateExam(int examId, [FromBody] Exam updatedExam)
        {
            try
            {
                var existingExam = _examService.GetExamById(examId);

                if (existingExam == null)
                {
                    return NotFound(); // Return a 404 Not Found response if the exam is not found
                }

                // Update the properties of the existing exam with the values from updatedExam
                existingExam.Examdate = updatedExam.Examdate;
                existingExam.Starttime = updatedExam.Starttime;
                existingExam.Endtime = updatedExam.Endtime;
                existingExam.Mark = updatedExam.Mark;
                existingExam.Subject = updatedExam.Subject;
                existingExam.Courseid = updatedExam.Courseid;

                // Call the service method to update the exam in the database
                _examService.UpdateExam(existingExam);

                return Ok(existingExam); // Return a 200 OK response with the updated exam
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "Internal server error"); // Return a 500 Internal Server Error response
            }
        }

        [HttpDelete("{examId}")]
        public async Task<IActionResult> DeleteExam(int examId)
        {
            try
            {
                await _examService.DeleteExam(examId);
                return Ok("Exam deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }

    }

}
