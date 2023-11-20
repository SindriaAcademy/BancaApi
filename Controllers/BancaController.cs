using Microsoft.AspNetCore.Mvc;
using BancaApi.Entities;
using System;
using System.Threading.Tasks;
using BancaApi.Repositories;

namespace BancaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancaController : ControllerBase
    {
        private readonly IBancaRepository _bancaRepository;

        public BancaController(IBancaRepository bancaRepository)
        {
            _bancaRepository = bancaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBancaAsync()
        {
            var banche = await _bancaRepository.GetBancheAsync();
            return Ok(banche);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBancaById(int id)
        {
            var banca = await _bancaRepository.GetBancaByIdAsync(id);
            if (banca == null)
            {
                return NotFound();
            }
            return Ok(banca);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanca([FromBody] BancaEntity banca)
        {
            if (banca == null)
            {
                return BadRequest("Banca data is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdBanca = await _bancaRepository.CreateBancaAsync(banca);
                return CreatedAtAction(nameof(GetBancaById), new { id = createdBanca.Id }, createdBanca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBanca(int id, [FromBody] BancaEntity banca)
        {
            if (banca == null)
            {
                return BadRequest();
            }

            var updated = await _bancaRepository.UpdateBancaAsync(id, banca);

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
        public async Task<IActionResult> DeleteBanca(int id)
        {
            var deleted = await _bancaRepository.DeleteBancaAsync(id);

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
