using Microsoft.AspNetCore.Mvc;
using BancaApi.Dtos;
using BancaApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BancaApi.Entities;

namespace BancaApi.Controllers
{
    [Route("api/banchefunc")]
    [ApiController]
    public class BancheFuncController : ControllerBase
    {
        private readonly IBancheFuncRepo _bancheFuncRepo;
        private readonly IMapper _mapper;

        public BancheFuncController(IBancheFuncRepo bancheFuncRepo, IMapper mapper)
        {
            _bancheFuncRepo = bancheFuncRepo ?? throw new ArgumentNullException(nameof(bancheFuncRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetBancheFuncs()
        {
            var bancheFuncDtos = await _bancheFuncRepo.GetBancheFuncsAsync();
            return Ok(bancheFuncDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBancheFuncById(int id)
        {
            var bancheFuncDto = await _bancheFuncRepo.GetBancheFuncByIdAsync(id);

            if (bancheFuncDto == null)
            {
                return NotFound();
            }

            return Ok(bancheFuncDto);
        }

        [HttpGet("funzionalita/{idBanca}")]
        public async Task<IActionResult> GetFunzionalitaByBancaId(int idBanca)
        {
            var funzionalitaDto = await _bancheFuncRepo.GetFunzionalitaByBancaIdAsync(idBanca);

            if (funzionalitaDto == null || !funzionalitaDto.Any())
            {
                return NotFound("Nessuna funzionalità trovata per l'ID banca specificato.");
            }

            return Ok(funzionalitaDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBancheFunc([FromBody] BancheFuncDto bancheFuncDto)
        {
            try
            {
                var createdBancheFuncDto = await _bancheFuncRepo.AddBancheFuncAsync(bancheFuncDto);
                return CreatedAtAction(nameof(GetBancheFuncById), new { id = createdBancheFuncDto.Id }, createdBancheFuncDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBancheFunc(int id, [FromBody] BancheFuncDto bancheFuncDto)
        {
            if (bancheFuncDto == null)
            {
                return BadRequest();
            }

            var updated = await _bancheFuncRepo.UpdateBancheFuncAsync(id, bancheFuncDto);

            if (updated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("update-funzionalita/{idBanca}")]
        public async Task<IActionResult> UpdateFunzionalitaByBancaId(int idBanca, [FromBody] List<BancheFuncDto> bancheFuncDtos)
        {
            try
            {
                

                await _bancheFuncRepo.DeleteBancheFuncByBancaIdAsync(idBanca);

                foreach (var bancheFuncDto in bancheFuncDtos)
                {
                    bancheFuncDto.IdBanca = idBanca;
                    await _bancheFuncRepo.AddBancheFuncAsync(bancheFuncDto);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("update-funz/{idBanca}")]
        public async Task<IActionResult> UpdateFunzionalitaByBancaIdAsync(int idBanca, [FromBody] List<FunzionalitaEntity> funzionalitaList)
        {
            try
            {
                await _bancheFuncRepo.DeleteBancheFuncByBancaIdAsync(idBanca);

                foreach (var funzionalita in funzionalitaList)
                {
                    var bancheFuncDto = new BancheFuncDto
                    {
                        IdBanca = idBanca,
                        IdFunzionalita = funzionalita.Id  
                    };

                    await _bancheFuncRepo.AddBancheFuncAsync1(bancheFuncDto);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBancheFunc(int id)
        {
            var deleted = await _bancheFuncRepo.DeleteBancheFuncAsync(id);

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
