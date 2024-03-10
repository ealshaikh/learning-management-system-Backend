using LMS.Core.Data;
using LMS.Core.Service;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }


        [HttpPost]
        [Route("UploadImage")]
        public Student UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";

            var fullPath = Path.Combine("C:\\Users\\Esraa\\OneDrive - just.edu.jo\\FinalProject\\MasterMind\\src\\assets\\UploadImages", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Student student = new Student();
            student.Profileimage = fileName;
            return student;
        }


        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<List<Student>> GetAllStudent()
        {
            return await _studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("GetStudentById/{id}")]
        public async Task<Student> GetStudentById(int id)
        {
            return await _studentService.GetStudentByID(id);
        }

        [HttpGet]
        [Route("GetStudentsCount")]
        public async Task<int> GetStudentsCount()
        {
            return await _studentService.GetStudentsCount();
        }


        //[HttpPost ("CreateStudent")]
        //public async void CreateStudent(Student student)
        //{
        //    Console.WriteLine($"Received data: {Newtonsoft.Json.JsonConvert.SerializeObject(student)}");

        //    _studentService.CreateStudent(student);

        //}
        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine($"Received data: {Newtonsoft.Json.JsonConvert.SerializeObject(student)}");

                _studentService.CreateStudent(student);

                // Return a JSON response with a message property
                return Ok(new { message = "Created Successfully" });
            }
            else
            {
                return BadRequest("Invalid data. Please check your input.");
            }
        }


        [HttpDelete("DeleteStudent/{id}")]
        public async void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }

        [HttpPut ("UpdateStudent")]
        public async void UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
        }

        [HttpGet]
        [Route("GetStudentGrades/{studentID}")]
        public IActionResult GetStudentGrades(int studentID)
        {
            try
            {
                var grades = _studentService.GetStudentGrades(studentID);

                if (grades == null || !grades.Any())
                {
                    return NotFound($"No grades found for student ID {studentID}");
                }

                return Ok(grades);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }






        [HttpGet]
        [Route("GetPassedStudents/{courseID}")]
        public IActionResult GetPassedStudents(int courseID)
        {

            try
            {

                var PassedStudents = _studentService.GetPassedStudents(courseID);
                // !PassedStudents.Any() checks if the PassedStudents collection does not contain any elements.
                if (PassedStudents == null || !PassedStudents.Any())
                {
                    return NotFound($"No passed students found for course ID {courseID}");
                }
                return Ok(PassedStudents);

            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }








    }
}
