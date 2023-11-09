using Microsoft.AspNetCore.Mvc;
using BancaApi.Entities;
using BancaApi.Repositories;

namespace BancaApi.Controllers
{
    [Route("api/conti")]
    [ApiController]
    public class ContoController : ControllerBase
    {
        private readonly IContoRepository _contoRepository;

        public ContoController(IContoRepository contoRepository)
        {
            _contoRepository = contoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetConti()
        {
            var conti = await _contoRepository.GetContiAsync();
            return Ok(conti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContoById(int id)
        {
            var conto = await _contoRepository.GetContoByIdAsync(id);
            if (conto == null)
            {
                return NotFound();
            }
            return Ok(conto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConto([FromBody] ContoEntity conto)
        {
            try
            {
                var createdConto = await _contoRepository.CreateContoAsync(conto);
                return CreatedAtAction("GetContoById", new { id = createdConto.Id }, createdConto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConto(int id, [FromBody] ContoEntity conto)
        {
            if (conto == null)
            {
                return BadRequest();
            }

            var updated = await _contoRepository.UpdateContoAsync(id, conto);

            if (updated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConto(int id)
        {
            var deleted = await _contoRepository.DeleteContoAsync(id);

            if (deleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
