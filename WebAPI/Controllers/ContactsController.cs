using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete;
using WebAPI.Entities.Concrete;
using WebAPI.Entities.DTO_s;
using WebAPI.Services.Abstract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetContactsWithCompanyAndCountryName()
        {
            try
            {
                var result = _contactService.GetContactsWithCompanyAndCountry();
                if (result == null)
                {
                    return NotFound("List is empty.");
                }

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        [HttpGet("getbyfilter/{companyId}/{countryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterContact(int companyId, int countryId)
        {
            try
            {
                var result = _contactService.FilterContact(companyId, countryId);

                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }


        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _contactService.GetAll();
                if (result == null)
                {
                    return NotFound("List is empty.");
                }
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = _contactService.GetById(id);

                if (result is null)
                {
                    return NotFound($"Entered ID {id} is not found.");
                }
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _contactService.GetById(id);
                if (result != null)
                {
                    _contactService.Delete(id);
                    return NoContent();
                }
                else if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Contact contact)
        {
            try
            {
                int createdContactId = _contactService.Create(contact);
                if (createdContactId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdContactId }, contact);
                }
                else
                {
                    return BadRequest("Contact creation failed.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }

        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromBody] Contact contact)
        {
            try
            {
                if (contact == null)
                    return NotFound("Contact not found.");
                else if (!(contact.ContactId == contact.ContactId) || contact.ContactId <= 0)
                {
                    return NotFound("Contact Id not found.");
                }
                else if (contact != null)
                {
                    _contactService.Update(contact);
                    return Ok("Contact updated.");
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }
    }
}
