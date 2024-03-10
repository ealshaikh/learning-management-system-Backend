using LMS.Core.Data;
using LMS.Core.Service;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendenceService _attendanceService;

        public AttendanceController(IAttendenceService attendanceService)
        {
            this._attendanceService = attendanceService;
        }

        [HttpGet]
        [Route("GetAllAttendances")]
        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await _attendanceService.GetAllAttendances();
        }

        [HttpGet]
        [Route("GetAttendanceById/{id}")]
        public async Task<Attendance> GetAttendanceById(int id)
        {
            return await _attendanceService.GetAttendanceById(id);
        }

        [HttpGet]
        [Route("GetAttendanceCount")]
        public async Task<int> GetAttendanceCount()
        {
            return await _attendanceService.GetAttendanceCount();

        }

        [HttpPost]
        [Route("CreateAttendance")]
        public IActionResult CreateAttendance([FromBody] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine($"Received data: {Newtonsoft.Json.JsonConvert.SerializeObject(attendance)}");

                _attendanceService.CreateAttendance(attendance);

                // Return a JSON response with a message property
                return Ok(new { message = "Created Successfully" });
            }
            else
            {
                return BadRequest("Invalid data. Please check your input.");
            }
        }

        [HttpDelete]
        [Route("DeleteAttendance/{attendanceID}")]
        public async void DeleteAttendance(int attendanceID)
        {
            _attendanceService.DeleteAttendance(attendanceID);
        }

        [HttpPut]
        [Route("UpdateAttendance")]
        public async void UpdateAttendance(Attendance attendance)
        {
            _attendanceService.UpdateAttendance(attendance);
        }

        [HttpGet]
        [Route("GetAttendancesBySection/{sectionID}")]
        public async Task<List<Attendance>> GetAttendancesBySection(int sectionID)
        {
            return await _attendanceService.GetAttendancesBySection(sectionID);
        }


        [HttpGet]
        [Route("GetAttendancesByStudent/{studentID}")]
        public async Task<List<Attendance>> GetAttendancesByStudent(int studentID)
        {
            return await _attendanceService.GetAttendancesByStudent(studentID);
        }

    }
}
