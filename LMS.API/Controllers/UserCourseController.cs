using LMS.Core.Data;
using LMS.Core.Service;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _userCourseService;

        public UserCourseController(IUserCourseService userCourseService)
        {
            this._userCourseService = userCourseService;
        }





        [HttpGet("GetAllUsercourse")]
        public async Task<ActionResult<List<Usercourse>>> GetAllUsercourse()
        {
            try
            {
                var Usercourse = await _userCourseService.GetAllUsercourse();
                return Ok(Usercourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetUsercourseByID/{id}")]
        public async Task<ActionResult<Usercourse>> GetUsercourseByID(int id)
        {
            try
            {
                var Usercourse = await _userCourseService.GetUsercourseById(id);
                if (Usercourse == null)
                {
                    return NotFound($"Usercourse with ID {id} not found.");
                }

                return Ok(Usercourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetUsercourseCount")]
        public async Task<ActionResult<int>> GetUsercourseCount()
        {
            try
            {
                var Usercourse = await _userCourseService.GetUsercourseCount();
                return Ok(Usercourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateUsercourse")]
        public ActionResult CreateUsercourse([FromBody] Usercourse Usercourse)
        {
            try
            {
                _userCourseService.CreateUsercourse(Usercourse);
                return CreatedAtAction(nameof(GetUsercourseByID), new { id = Usercourse.Usercourseid }, Usercourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateUserCourse")]
        public async void UpdateUserCourse(Usercourse Usercourse)
        {
            _userCourseService.UpdateUsercourse(Usercourse);
        }

        [HttpDelete("DeleteUserCourse/{id}")]
        public async void DeleteUserCourse(int id)
        {
            _userCourseService.DeleteUsercourse(id);
        }


        [HttpGet("FilterCourseSection/{courseID}")]
        public async Task<ActionResult<List<string>>> FilterCourseSection(int courseID)
        {
            try
            {
                var FilteredCourseSection = await _userCourseService.FilterCourseSection(courseID);
                return Ok(FilteredCourseSection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("FilterSectionCourses/{sectionid}")]
        public async Task<ActionResult<List<string>>> FilterSectionCourses(int sectionid)
        {
            try
            {
                var FilteredSectionCourses = await _userCourseService.FilterSectionCourses(sectionid);
                return Ok(FilteredSectionCourses);
            }


            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
    

    }
