using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entities.Concrete;
using WebAPI.Services.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _companyService.GetAllAsync();

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
                var result = await _companyService.GetByIdAsync(id);

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
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            var result = await _companyService.CreateAsync(company);
            return CreatedAtAction(nameof(GetById), new { id = result.CompanyId }, result);
        }


        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            await _companyService.UpdateAsync(company);
            await _companyService.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteAsync(id);
            await _companyService.SaveAsync();
            return NoContent();
        }
    }
}
