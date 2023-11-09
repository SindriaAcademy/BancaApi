using Microsoft.AspNetCore.Mvc;
using BancaApi.Entities;
using BancaApi.Repositories;

namespace BancaApi.Controllers
{
    [Route("api/utenti")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteRepository _utenteRepository;

        public UtenteController(IUtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUtenti()
        {
            var utenti = await _utenteRepository.GetUtentiAsync();
            return Ok(utenti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUtenteById(int id)
        {
            var utente = await _utenteRepository.GetUtenteByIdAsync(id);
            if (utente == null)
            {
                return NotFound();
            }
            return Ok(utente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUtente([FromBody] UtenteEntity utente)
        {
            try
            {
                var createdUtente = await _utenteRepository.CreateUtenteAsync(utente);
                return CreatedAtAction("GetUtenteById", new { id = createdUtente.Id }, createdUtente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUtente(int id, [FromBody] UtenteEntity utente)
        {
            if (utente == null)
            {
                return BadRequest();
            }

            var updated = await _utenteRepository.UpdateUtenteAsync(id, utente);

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
        public async Task<IActionResult> DeleteUtente(int id)
        {
            var deleted = await _utenteRepository.DeleteUtenteAsync(id);

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
