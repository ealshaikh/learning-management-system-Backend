using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherUserLoginController : ControllerBase
    {
        private readonly ITeacherUserLoginService teacherUserLoginService;

        public TeacherUserLoginController(ITeacherUserLoginService teacherUserLoginService)
        {
            this.teacherUserLoginService = teacherUserLoginService;
        }


        [HttpPost]
        public Task<IActionResult> CreateTeacherUserLogin([FromBody] int teacherId, int roleId, string email, string password)
        {
            try
            {
                teacherUserLoginService.CreateTeacherUserLogin(teacherId, roleId, email, password);
                return Task.FromResult<IActionResult>(Ok("Teacher created successfully"));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return Task.FromResult<IActionResult>(StatusCode(500, "Internal server error"));
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeacherUserLogin()
        {
            try
            {
                var teacherUserLogins = await teacherUserLoginService.GetAllTeacherUserLogin();
                return Ok(teacherUserLogins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpDelete("{teacherUserLoginId}")]
        public async Task<IActionResult> DeleteTeacherUserLogin(int teacherUserLoginId)
        {
            try
            {
                // Assuming you have a method in your service to delete a teacher user login
                await teacherUserLoginService.DeleteTeacherUserLogin(teacherUserLoginId);
                return Ok("Teacher user login deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{teacherUserLoginId}")]
        public async Task<IActionResult> GetTeacherUserLogin(int teacherUserLoginId)
        {
            try
            {
                var teacherUserLogin = await teacherUserLoginService.GetTeacherUserLogin(teacherUserLoginId);

                if (teacherUserLogin != null)
                {
                    return Ok(teacherUserLogin);
                }
                else
                {
                    return NotFound($"TeacherUserLogin with ID {teacherUserLoginId} not found");
                }
            }
            catch (Exception ex)
            {
                // Log the exception with additional details


                // Rethrow the exception for further handling or let it propagate
                throw;
            }
        }
        [HttpPut("{teacherUserLoginId}")]
        public async Task<IActionResult> UpdateTeacherUserLogin(int teacherUserLoginId, int teacherId, int roleId, string email, string password)
        {
            try
            {
                // Assuming you have a method in your service to update a teacher user login
                await teacherUserLoginService.UpdateTeacherUserLogin(teacherUserLoginId, teacherId, roleId, email, password);
                return Ok("Teacher user login updated successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }


    }

}
