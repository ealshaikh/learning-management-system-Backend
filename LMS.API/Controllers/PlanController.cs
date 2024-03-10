using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS.Core.DTO;
using LMS.Infra.Service;
using System;
using Oracle.ManagedDataAccess.Client;
using Microsoft.AspNetCore.Authorization;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            this._planService = planService;
        }

        [HttpGet("GetAllPlans")]
       

        public async Task<ActionResult<List<Plan>>> GetAllPlans()
        {
            try
            {
                var plans = await _planService.GetAllPlans();
                return Ok(plans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetPlanByID/{id}")]
        [CheckClaims("roleid", "1")]
        public async Task<ActionResult<Plan>> GetPlanByID(int id)
        {
            try
            {
                var plan = await _planService.GetPlanByID(id);
                if (plan == null)
                {
                    return NotFound($"Plan with ID {id} not found.");
                }

                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetPlanCount")]
        public async Task<ActionResult<int>> GetPlanCount()
        {
            try
            {
                var planCount = await _planService.GetPlanCount();
                return Ok(planCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreatePlan")]
        public ActionResult CreatePlan([FromBody] Plan plan)
        {
            try
            {
                _planService.CreatePlan(plan);
                //return CreatedAtAction(nameof(GetPlanByID), new { id = plan.Planid }, plan);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdatePlan")]
        public async void UpdatePlan(Plan plan)
        {
            _planService.UpdatePlan(plan);
        }

        [HttpDelete("DeletePlan/{id}")]
        public async void DeletePlan(int id)
        {
            _planService.DeletePlan(id);
        }

        [HttpGet("FilterPlansByCourseID/{courseID}")]
        public async Task<ActionResult<List<string>>> FilterPlansByCourseID(int courseID)
        {
            try
            {
                var filteredPlans = await _planService.FilterPlansByCourseID(courseID);
                return Ok(filteredPlans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("FilterCoursesByPlanID/{planID}")]
        public async Task<ActionResult<List<string>>> FilterCoursesByPlanID(int planID)
        {
            try
            {
                var filteredCourses = await _planService.FilterCoursesByPlanID(planID);
                return Ok(filteredCourses);
            }


            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        
       


        [HttpPost("AssignCoursesToPlan")]
        public ActionResult AssignCoursesToPlan([FromBody] AssignCoursesRequest request)
        {
            try
            {
                _planService.AssignCoursesToPlan(request.PlanID, request.CourseID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }





        [HttpDelete("DeleteCourseFromPlan")]
        public ActionResult DeleteCourseFromPlan([FromBody] AssignCoursesRequest request)
        {
            try
            {
                _planService.DeleteCourseFromPlan(request.PlanID, request.CourseID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("UploadImage")]
        public Plan UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";

            var fullPath = Path.Combine("E:\\Tahaluf\\Final_Project\\MindMaster_FrontEnd\\MindMaster\\src\\assets\\UploadImages", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Plan plan = new Plan();
            plan.Coverimage = fileName;
            return plan;
        }

    }

}
