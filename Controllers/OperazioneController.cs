using Microsoft.AspNetCore.Mvc;
using BancaApi.Entities;
using BancaApi.Repositories;

namespace BancaApi.Controllers
{
    [Route("api/operazioni")]
    [ApiController]
    public class OperazioneController : ControllerBase
    {
        private readonly IOperazioneRepository _operazioneRepository;

        public OperazioneController(IOperazioneRepository operazioneRepository)
        {
            _operazioneRepository = operazioneRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOperazioni()
        {
            var operazioni = await _operazioneRepository.GetOperazioniAsync();
            return Ok(operazioni);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperazioneById(int id)
        {
            var operazione = await _operazioneRepository.GetOperazioneByIdAsync(id);
            if (operazione == null)
            {
                return NotFound();
            }
            return Ok(operazione);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperazione([FromBody] OperazioneEntity operazione)
        {
            try
            {
                var createdOperazione = await _operazioneRepository.CreateOperazioneAsync(operazione);
                return CreatedAtAction("GetOperazioneById", new { id = createdOperazione.Id }, createdOperazione);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOperazione(int id, [FromBody] OperazioneEntity operazione)
        {
            if (operazione == null)
            {
                return BadRequest();
            }

            var updated = await _operazioneRepository.UpdateOperazioneAsync(id, operazione);

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
        public async Task<IActionResult> DeleteOperazione(int id)
        {
            var deleted = await _operazioneRepository.DeleteOperazioneAsync(id);

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
