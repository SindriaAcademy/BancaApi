using Microsoft.AspNetCore.Mvc;
using BancaApi.Entities;
using BancaApi.Repositories;
using BancaApi.Dtos;

namespace BancaApi.Controllers
{
    [Route("api/movimenti")]
    [ApiController]
    public class MovimentiController : ControllerBase
    {
        private readonly IUtenteRepository _utenteRepository;
        private readonly IContoRepository _contoRepository;
        private readonly IOperazioneRepository _operazioneRepository;

        public MovimentiController(IUtenteRepository utenteRepository, IContoRepository contoRepository, IOperazioneRepository operazioneRepository)
        {
            _utenteRepository = utenteRepository;
            _contoRepository = contoRepository;
            _operazioneRepository = operazioneRepository;
        }

        [HttpPost("prelievo/{idUtente}")]
        public async Task<IActionResult> Prelievo(int idUtente, [FromBody] OperazioneDto operazione)
        {
            var utente = await _utenteRepository.GetUtenteByIdAsync(idUtente);

            if (utente == null)
            {
                return NotFound("Utente non trovato");
            }

            var conto = await _contoRepository.GetContoByUtenteIdAsync(idUtente);

            if (conto == null)
            {
                return NotFound("Conto non trovato per l'utente");
            }

            if (operazione.Quantita <= 0)
            {
                return BadRequest("La quantità del prelievo deve essere positiva");
            }

            if (conto.Saldo < operazione.Quantita)
            {
                return BadRequest("Fondi insufficienti per il prelievo");
            }

            conto.Saldo -= operazione.Quantita;
            operazione.IdBanca = utente.IdBanca;
            operazione.IdUtente = idUtente;
            operazione.Funzionalita = "Prelievo";
            operazione.DataOperazione = DateTime.Now;
            conto.DataUltimaOperazione = operazione.DataOperazione;

            // Salva l'operazione e il conto aggiornato
            await _contoRepository.UpdateContoAsync(conto.Id, conto);
            await _operazioneRepository.CreateOperazioneAsync(operazione);

            return Ok("Prelievo effettuato con successo");
        }

        [HttpPost("versamento/{idUtente}")]
        public async Task<IActionResult> Versamento(int idUtente, [FromBody] OperazioneDto operazione)
        {
            var utente = await _utenteRepository.GetUtenteByIdAsync(idUtente);

            if (utente == null)
            {
                return NotFound("Utente non trovato");
            }

            var conto = await _contoRepository.GetContoByUtenteIdAsync(idUtente);

            if (conto == null)
            {
                return NotFound("Conto non trovato per l'utente");
            }

            if (operazione.Quantita <= 0)
            {
                return BadRequest("La quantità del versamento deve essere positiva");
            }

            conto.Saldo += operazione.Quantita;
            operazione.IdBanca = utente.IdBanca;
            operazione.IdUtente = idUtente;
            operazione.Funzionalita = "Versamento";
            operazione.DataOperazione = DateTime.Now;
            conto.DataUltimaOperazione = operazione.DataOperazione;

            await _contoRepository.UpdateContoAsync(conto.Id, conto);
            await _operazioneRepository.CreateOperazioneAsync(operazione);

            return Ok("Versamento effettuato con successo");
        }

        [HttpGet("saldo/{idUtente}")]
        public async Task<IActionResult> GetSaldo(int idUtente)
        {
            var utente = await _utenteRepository.GetUtenteByIdAsync(idUtente);

            if (utente == null)
            {
                return NotFound("Utente non trovato");
            }

            var conto = await _contoRepository.GetContoByUtenteIdAsync(idUtente);

            if (conto == null)
            {
                return NotFound("Conto non trovato per l'utente");
            }

            var saldoResponse = new { Saldo = conto.Saldo }; // Return as a JSON object
            return Ok(saldoResponse);
        }


        [HttpGet("registro-operazioni/{idUtente}")]
        public async Task<IActionResult> GetRegistroOperazioni(int idUtente)
        {
            var utente = await _utenteRepository.GetUtenteByIdAsync(idUtente);

            if (utente == null)
            {
                return NotFound("Utente non trovato");
            }

            var operazioni = await _operazioneRepository.GetOperazioniByUtenteIdAsync(idUtente);

            return Ok(operazioni);
        }
    }
}
