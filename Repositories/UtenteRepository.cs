using BancaApi.DbContexts;
using BancaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancaApi.Repositories
{
    public class UtenteRepository : IUtenteRepository
    {
        private readonly BancaInfoContext _context;

        public UtenteRepository(BancaInfoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UtenteEntity>> GetUtentiAsync()
        {
            return await _context.Utenti.ToListAsync();
        }

        public async Task<UtenteEntity> GetUtenteByIdAsync(int id)
        {
            return await _context.Utenti.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UtenteEntity> CreateUtenteAsync(UtenteEntity utente)
        {
            if (utente == null)
            {
                throw new ArgumentNullException(nameof(utente));
            }

            _context.Utenti.Add(utente);
            await _context.SaveChangesAsync();

            return utente;
        }

        public async Task<bool> UpdateUtenteAsync(int id, UtenteEntity utente)
        {
            if (utente == null)
            {
                throw new ArgumentNullException(nameof(utente));
            }

            var existingUtente = await _context.Utenti.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUtente == null)
            {
                return false;
            }
            
            existingUtente.NomeUtente = utente.NomeUtente;
            existingUtente.Password = utente.Password;

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
