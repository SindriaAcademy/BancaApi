using Microsoft.AspNetCore.Mvc;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancaApi.Controllers
{
    [Route("api/operazioni")]
    [ApiController]
    public class OperazioneController : ControllerBase
    {
        private readonly IOperazioneRepository _operazioneRepository;
        private readonly IMapper _mapper;

        public OperazioneController(IOperazioneRepository operazioneRepository, IMapper mapper)
        {
            _operazioneRepository = operazioneRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOperazioni()
        {
            var operazioni = await _operazioneRepository.GetOperazioniAsync();
            var operazioniDto = _mapper.Map<IEnumerable<OperazioneDto>>(operazioni);
            return Ok(operazioniDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperazioneById(int id)
        {
            var operazione = await _operazioneRepository.GetOperazioneByIdAsync(id);
            if (operazione == null)
            {
                return NotFound();
            }

            var operazioneDto = _mapper.Map<OperazioneDto>(operazione);
            return Ok(operazioneDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperazione([FromBody] OperazioneDto operazioneDto)
        {
            try
            {
                //var operazioneEntity = _mapper.Map<OperazioneEntity>(operazioneDto);
                var createdOperazione = await _operazioneRepository.CreateOperazioneAsync(operazioneDto);

                var createdOperazioneDto = _mapper.Map<OperazioneDto>(createdOperazione);
                return CreatedAtAction(nameof(GetOperazioneById), new { id = createdOperazioneDto.Id }, createdOperazioneDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOperazione(int id, [FromBody] OperazioneDto operazioneDto)
        {
            if (operazioneDto == null)
            {
                return BadRequest();
            }

           // var operazioneEntity = _mapper.Map<OperazioneEntity>(operazioneDto);
            var updated = await _operazioneRepository.UpdateOperazioneAsync(id, operazioneDto);

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
