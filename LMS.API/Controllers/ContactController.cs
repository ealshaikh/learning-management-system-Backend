using LMS.Core.Data;
using LMS.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public ActionResult CreateContact([FromBody] Contact conatct)
        {
            try
            {
                 _contactService.CreateContact(conatct);
                return Ok("Contact created successfully.");
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "Internal Server Error");
            }
        }






        [HttpGet("{contactId}")]
        public IActionResult GetContact(int contactId)
        {
            try
            {
                var contact = _contactService.GetContact(contactId);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet]
        public List<Contact> GetAllContacts()
        {
            return _contactService.GetAllContacts();

        }
        [HttpPut("{contactId}")]
        public IActionResult UpdateContact(int contactId, [FromBody] string message, string email, string fullName, string title)
        {
            try
            {
                _contactService.UpdateContact(contactId, message, email, fullName, title);
                return Ok("Contact updated successfully.");
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpDelete("{contactId}")]
        public IActionResult DeleteContact(int contactId)
        {
            try
            {
                _contactService.DeleteContact(contactId);
                return Ok("Contact deleted successfully.");
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "Internal Server Error");
            }
        }
    }

}
