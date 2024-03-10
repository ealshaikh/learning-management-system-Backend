using LMS.Core.Data;
using LMS.Core.Service;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSectionController : ControllerBase
    {
        private readonly IUserSectionService _userSectionService;

        public UserSectionController(IUserSectionService userSectionService)
        {
            _userSectionService = userSectionService;
        }


        [HttpGet("GetAllUserSection")]
        public async Task<ActionResult<List<Usersection>>> GetAllUserSection()
        {
            try
            {
                var UserSectio = await _userSectionService.GetAllUserInSections();
                return Ok(UserSectio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetUserSectionByID/{id}")]
        public async Task<ActionResult<Usersection>> GetUserSectionByID(int id)
        {
            try
            {
                var UserSection = await _userSectionService.GetUserInSectionById(id);
                if (UserSection == null)
                {
                    return NotFound($"UserSection with ID {id} not found.");
                }

                return Ok(UserSection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetUserSectionCount")]
        public async Task<ActionResult<int>> GetUserSectionCount()
        {
            try
            {
                var UserSectioncount = await _userSectionService.GetUserInSectionCount();
                return Ok(UserSectioncount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateUserSection")]
        public ActionResult CreateUserSection([FromBody] Usersection usersection)
        {
            try
            {
                _userSectionService.CreateUserInSection(usersection);
                return CreatedAtAction(nameof(GetUserSectionByID), new { id = usersection.Usersectionid }, usersection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateUserSection")]
        public async void UpdateUserSection(Usersection usersection)
        {
            _userSectionService.UpdateUserInSection(usersection);
        }

        [HttpDelete("DeleteUserSection/{id}")]
        public async void DeleteUserSection(int id)
        {
            _userSectionService.DeleteUserInSection(id);
        }


    }
}
