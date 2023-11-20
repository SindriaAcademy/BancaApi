using AutoMapper;
using BancaApi.DbContexts;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BancaApi.Repositories
{
    public class UtenteRepository : IUtenteRepository
    {
        private readonly BancaInfoContext _context;
        private readonly IMapper _mapper;

        public UtenteRepository(BancaInfoContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UtenteDto>> GetUtentiAsync()
        {
            var utenti = await _context.Utenti.ToListAsync();
            return _mapper.Map<IEnumerable<UtenteDto>>(utenti);
        }

        public async Task<UtenteDto> GetUtenteByIdAsync(int id)
        {
            var utente = await _context.Utenti.FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UtenteDto>(utente);
        }

        public async Task<IEnumerable<UtenteDto>> GetUtentiByBancaIdAsync(int idBanca)
        {
            var utenti = await _context.Utenti
                .Where(u => u.IdBanca == idBanca)
                .Select(u => new UtenteDto
                {
                    Id = u.Id,
                    NomeUtente = u.NomeUtente,
                    Bloccato = u.Bloccato
                })
                .ToListAsync();

            return utenti;
        }


        public async Task<UtenteDto> CreateUtenteAsync(UtenteDto utenteDto)
        {
            if (utenteDto == null)
            {
                throw new ArgumentNullException(nameof(utenteDto));
            }
          
            utenteDto.Password = PasswordHasher.HashPassword(utenteDto.Password);
            var utenteEntity = _mapper.Map<UtenteEntity>(utenteDto);

            _context.Utenti.Add(utenteEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<UtenteDto>(utenteEntity);
        }

        public async Task<bool> UpdateUtenteAsync(int id, UtenteDto utenteDto)
        {
            if (utenteDto == null)
            {
                throw new ArgumentNullException(nameof(utenteDto));
            }

            var existingUtente = await _context.Utenti.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUtente == null)
            {
                return false;
            }

            existingUtente.NomeUtente = utenteDto.NomeUtente;
            existingUtente.Password = PasswordHasher.HashPassword(utenteDto.Password);
            existingUtente.Bloccato = utenteDto.Bloccato;
            existingUtente.Role = utenteDto.Role;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUtenteAsync(int id)
        {
            var existingUtente = await _context.Utenti.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUtente == null)
            {
                return false;
            }

            _context.Utenti.Remove(existingUtente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
