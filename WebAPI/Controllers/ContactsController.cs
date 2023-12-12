using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities.Concrete;
using WebAPI.Services.Abstract;

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


        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _contactService.GetAllAsync();

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
                var result = await _contactService.GetByIdAsync(id);

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


        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Contact contact)
        {
            var result = await _contactService.CreateAsync(contact);
            return CreatedAtAction(nameof(GetById), new { id = result.ContactId }, result);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            await _contactService.UpdateAsync(contact);
            await _contactService.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteAsync(id);
            await _contactService.SaveAsync();
            return NoContent();
        }
    }
}
