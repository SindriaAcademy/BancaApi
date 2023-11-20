using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Repositories;

namespace BancaApi.Controllers
{
    [Route("api/conti")]
    [ApiController]
    public class ContoController : ControllerBase
    {
        private readonly IContoRepository _contoRepository;
        private readonly IMapper _mapper;
        private readonly IUtenteRepository _utenteRepository;

        public ContoController(IContoRepository contoRepository, IMapper mapper, IUtenteRepository utenteRepository)
        {
            _contoRepository = contoRepository;
            _mapper = mapper;
            _utenteRepository = utenteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetConti()
        {
            var conti = await _contoRepository.GetContiAsync();
            var contiDto = _mapper.Map<IEnumerable<ContoDto>>(conti);
            return Ok(contiDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContoById(int id)
        {
            var conto = await _contoRepository.GetContoByIdAsync(id);

            if (conto == null)
            {
                return NotFound();
            }

            var contoDto = _mapper.Map<ContoDto>(conto);
            return Ok(contoDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConto([FromBody] ContoDto contoDto)
        {
            try
            {
                // Check if the provided IdUtente is valid
                var utente = await _utenteRepository.GetUtenteByIdAsync(contoDto.IdUtente);

                if (utente == null)
                {
                    return NotFound($"Utente with Id {contoDto.IdUtente} not found.");
                }

                // Map ContoDto to ContoEntity
                var contoEntity = _mapper.Map<ContoEntity>(contoDto);

                // Associate the Conto with the Utente
                contoEntity.IdUtente = contoDto.IdUtente;

                // Create the Conto
                var createdConto = await _contoRepository.CreateContoAsync(contoDto);

                // Map the created Conto to ContoDto
                var createdContoDto = _mapper.Map<ContoDto>(createdConto);

                // Return the created ContoDto
                return CreatedAtAction(nameof(GetContoById), new { id = createdContoDto.Id }, createdContoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConto(int id, [FromBody] ContoDto contoDto)
        {
            try
            {
                // Check if the provided IdUtente is valid
                var utente = await _utenteRepository.GetUtenteByIdAsync(contoDto.IdUtente);

                if (utente == null)
                {
                    return NotFound($"Utente with Id {contoDto.IdUtente} not found.");
                }

                // Map ContoDto to ContoEntity
                var contoEntity = _mapper.Map<ContoEntity>(contoDto);

                // Associate the Conto with the Utente
                contoEntity.IdUtente = contoDto.IdUtente;

                // Update the Conto
                var updated = await _contoRepository.UpdateContoAsync(id, contoDto);

                if (updated)
                {
                    return Ok();
                }
                else
                {
                    return NotFound($"Conto with Id {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
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
