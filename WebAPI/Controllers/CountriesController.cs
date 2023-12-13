using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entities.Concrete;
using WebAPI.Services.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _countryService.GetAll();
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
                var result = _countryService.GetById(id);

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
                var result = _countryService.GetById(id);
                if (result != null)
                {
                    _countryService.Delete(id);
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
        public IActionResult Create([FromBody] Country country)
        {
            try
            {
                int createdContactId = _countryService.Create(country);
                if (createdContactId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdContactId }, country);
                }
                else
                {
                    return BadRequest("Country creation failed.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }

        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromBody] Country country)
        {
            try
            {
                if (country == null)
                    return NotFound("Country not found.");
                else if (!(country.CountryId == country.CountryId) || country.CountryId <= 0)
                {
                    return NotFound("Country Id not found.");
                }
                else if (country != null)
                {
                    _countryService.Update(country);
                    return Ok();
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
