using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpPost]
        [Route("UploadImage")]
        public Teacher UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";

            var fullPath = Path.Combine("E:\\Tahaluf\\Final_Project\\MindMaster_FrontEnd\\MindMaster\\src\\assets\\UploadImages", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Teacher teacher = new Teacher();
            teacher.Profileimage = fileName;
            return teacher;
        }


        [HttpGet]
        public List<Teacher> GetAllTeachers()
        {
            return teacherService.GetAllTeachers();
        }

        [HttpPost]
        public Task<IActionResult> CreateTeacher([FromBody] Teacher teacher)
        {
            try
            {
                teacherService.CreateTeacher(teacher);
                return Task.FromResult<IActionResult>(Ok("Teacher created successfully"));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return Task.FromResult<IActionResult>(StatusCode(500, "Internal server error"));
            }
        }
        [HttpPut("{teacherId}")]
        public async Task<IActionResult> UpdateTeacher(int teacherId, [FromBody] Teacher teacher)
        {
            try
            {
                // Assuming you have a method in your service to update a teacher
                teacher.Teacherid = teacherId; // Assign the ID from the route parameter
                await teacherService.UpdateTeacher(teacher);
                return Ok("Teacher updated successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacherById(int teacherId)
        {
            var tch = await teacherService.GetTeacherById(teacherId);

            if (tch == null)
            {
                return NotFound();
            }

            return Ok(tch);
        }


        [HttpGet("teacherCount")]
        public async Task<IActionResult> GetTeacherCount()
        {
            try
            {
                // Assuming you have a method in your service to get the teacher count
                var teacherCount = await teacherService.GetTeacherCount();

                return Ok(new { TeacherCount = teacherCount });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            try
            {
                // Assuming you have a method in your service to delete a teacher
                await teacherService.DeleteTeacher(teacherId);
                return Ok("Teacher deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }


    }

}
