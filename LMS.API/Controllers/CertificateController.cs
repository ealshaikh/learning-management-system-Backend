using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCertificate([FromBody] DateTime certificateDate, int studentId, int planId)
        {
            try
            {
                // Validate the input model as needed
                await _certificateService.CreateCertificate(certificateDate, studentId, planId);

                return Ok("Certificate created successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{certificateId}")]
        public async Task<IActionResult> GetCertificateById(int certificateId)
        {
            try
            {
                var certificate = await _certificateService.GetCertificateById(certificateId);
                if (certificate == null)
                {
                    return NotFound("Certificate not found");
                }

                return Ok(certificate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificate>>> GetAllCertificates()
        {
            var cards = await _certificateService.GetAllCertificates();

            if (!cards.Any()) // Ensure cards is not null before calling Any()
            {
                return NotFound("No certificates found");
            }

            return Ok(cards);
        }
        [HttpDelete("{certificateId}")]
        public async Task<IActionResult> DeleteCertificate(int certificateId)
        {
            try
            {
                await _certificateService.DeleteCertificate(certificateId);
                return Ok("Certificate deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
