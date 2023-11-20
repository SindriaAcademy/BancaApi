using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Repositories;
using BancaApi.Helpers;
using BancaApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BancaApi.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BancaApi.Controllers
{
    [Route("api/utenti")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteRepository _utenteRepository;
        private readonly IMapper _mapper;
        private readonly BancaInfoContext _bancaDb;

        public UtenteController(IUtenteRepository utenteRepository, IMapper mapper, BancaInfoContext bancaInfo)
        {
            _utenteRepository = utenteRepository;
            _mapper = mapper;
            _bancaDb = bancaInfo;

        }

        [HttpGet]
        public async Task<IActionResult> GetUtenti()
        {
            var utenti = await _utenteRepository.GetUtentiAsync();
            var utentiDto = _mapper.Map<IEnumerable<UtenteDto>>(utenti);
            return Ok(utentiDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUtenteById(int id)
        {
            var utente = await _utenteRepository.GetUtenteByIdAsync(id);

            if (utente == null)
            {
                return NotFound();
            }

            var utenteDto = _mapper.Map<UtenteDto>(utente);
            return Ok(utenteDto);
        }

        [HttpGet("byBanca/{idBanca}")]
        public async Task<IActionResult> GetUtentiByBancaId(int idBanca)
        {
            try
            {
                var utentiDto = await _utenteRepository.GetUtentiByBancaIdAsync(idBanca);

                if (utentiDto == null || !utentiDto.Any())
                {
                    return NotFound("Nessun utente trovato per l'ID banca specificato.");
                }

                return Ok(utentiDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore interno del server: {ex.Message}");
            }
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UtenteDto user)
        {
            if (user == null)
                return BadRequest("Invalid authentication data.");

            var userEntity = _mapper.Map<UtenteEntity>(user);

            var authenticatedUser = await _bancaDb.Utenti
                .FirstOrDefaultAsync(x => x.NomeUtente == userEntity.NomeUtente);
         

            if (authenticatedUser == null)
                return Unauthorized(new { Message = "Authentication failed. User not found or invalid credentials." });

            if (!PasswordHasher.VerifyPassword(userEntity.Password, authenticatedUser.Password))
            {
                return BadRequest(new { Message = "Password is incorrect" });
            }

            authenticatedUser.Token = CreateJwt(user);
            return Ok(new
            {
                idBanca = authenticatedUser.IdBanca,
                Token = authenticatedUser.Token,
                Message = "Login success"
            });


        }

        [HttpPost]
        public async Task<IActionResult> CreateUtente([FromBody] UtenteDto utenteDto)
        {
            try
            {
                //var utenteEntity = _mapper.Map<UtenteEntity>(utenteDto);

                utenteDto.Password = PasswordHasher.HashPassword(utenteDto.Password);
                utenteDto.Role = "User";
                utenteDto.Token = "";

                var createdUtente = await _utenteRepository.CreateUtenteAsync(utenteDto);

                var createdUtenteDto = _mapper.Map<UtenteDto>(createdUtente);

                if(PasswordHasher.VerifyPassword(utenteDto.Password, createdUtenteDto.Password))
                {
                    return BadRequest(new { Message = "Password is incorrect" });
                }
                return CreatedAtAction(nameof(GetUtenteById), new { id = createdUtenteDto.Id }, createdUtenteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUtente(int id, [FromBody] UtenteDto utenteDto)
        {
            try
            {
                var existingUtente = await _utenteRepository.GetUtenteByIdAsync(id);

                if (existingUtente == null)
                {
                    return NotFound();
                }

                existingUtente.NomeUtente = utenteDto.NomeUtente;
                existingUtente.Password = PasswordHasher.HashPassword(utenteDto.Password);
                existingUtente.Bloccato = utenteDto.Bloccato;
                existingUtente.Role = utenteDto.Role;

                var updatedUtente = await _utenteRepository.UpdateUtenteAsync(id, existingUtente);

                if (updatedUtente)
                {
                    var updatedUtenteDto = _mapper.Map<UtenteDto>(existingUtente);
                    return Ok(updatedUtenteDto);
                }
                else
                {
                    return StatusCode(500, "Si è verificato un errore durante l'aggiornamento dell'utente.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtente(int id)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPut("sblocca/{id}")]
        public async Task<IActionResult> SbloccaUtente(int id)
        {
            var utente = await _utenteRepository.GetUtenteByIdAsync(id);

            if (utente == null)
            {
                return NotFound();
            }

            if (!utente.Bloccato)
            {
                return BadRequest("L'utente non è bloccato.");
            }

            utente.Bloccato = false;

            var updatedUtente = await _utenteRepository.UpdateUtenteAsync(id, utente);

            if (updatedUtente != null)
            {
                var updatedUtenteDto = _mapper.Map<UtenteDto>(updatedUtente);
                return Ok(updatedUtenteDto);
            }
            else
            {
                return StatusCode(500, "Si è verificato un errore durante lo sblocco dell'utente.");
            }
        }


        private string CreateJwt(UtenteDto user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.NomeUtente)
            };

            if (!string.IsNullOrEmpty(user.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, user.Role));
            }

            var identity = new ClaimsIdentity(claims);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }
    }
}
