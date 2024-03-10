using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {

        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
        [HttpPost]
        public IActionResult CreateSection([FromBody] Section _section)
        {
            try
            {
                // Map the request data to your Section model or DTO
                Section section = new Section
                {
                    Sectionno = _section.Sectionno,


                    Sectionstatus = _section.Sectionstatus,
                    Starttime = _section.Starttime,
                    Endtime = _section.Endtime,
                    Material = _section.Material,
                    Sectioncapacity = _section.Sectioncapacity,
                    Planid = _section.Planid,
                    Courseid = _section.Courseid,
                    Teacherid = _section.Teacherid
                };

                // Call the service method to create the section
                _sectionService.CreateSection(section);

                // Return a 201 Created response with the created section
                return CreatedAtAction(nameof(GetSectionById), new { sectionId = section.Sectionid }, section);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{sectionId}")]
        public IActionResult GetSectionById(int sectionId)
        {
            try
            {
                var section = _sectionService.GetSectionById(sectionId);

                if (section != null)
                {
                    return Ok(section); // Return a 200 OK response with the section
                }

                return NotFound(); // Return a 404 Not Found response if the section is not found
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public List<Section> GetAllSections()
        {
            return _sectionService.GetAllSections();
        }
        [HttpDelete("{sectionId}")]
        public async Task<IActionResult> DeleteSection(int sectionId)
        {
            try
            {
                await _sectionService.DeleteSection(sectionId);
                return Ok("Section deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{sectionId}")]
        public async Task<IActionResult> UpdateSection(int sectionId, [FromBody] Section section)
        {
            try
            {
                section.Sectionid = sectionId; // Assign the ID from the route parameter
                await _sectionService.UpdateSection(section);
                return Ok("Section updated successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
