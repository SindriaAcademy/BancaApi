using BancaApi.DbContexts;
using BancaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancaApi.Repositories
{
    public class OperazioneRepository : IOperazioneRepository
    {
        private readonly BancaInfoContext _context;

        public OperazioneRepository(BancaInfoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OperazioneEntity>> GetOperazioniByUtenteIdAsync(int idUtente)
        {
            return await _context.Operazioni.Where(operazione => operazione.IdUtente == idUtente).ToListAsync();
        }

        public async Task<IEnumerable<OperazioneEntity>> GetOperazioniAsync()
        {
            return await _context.Operazioni.ToListAsync();
        }

        public async Task<OperazioneEntity> GetOperazioneByIdAsync(int id)
        {
            return await _context.Operazioni.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OperazioneEntity> CreateOperazioneAsync(OperazioneEntity operazione)
        {
            if (operazione == null)
            {
                throw new ArgumentNullException(nameof(operazione));
            }

            _context.Operazioni.Add(operazione);
            await _context.SaveChangesAsync();

            return operazione;
        }

        public async Task<bool> UpdateOperazioneAsync(int id, OperazioneEntity operazione)
        {
            if (operazione == null)
            {
                throw new ArgumentNullException(nameof(operazione));
            }

            var existingOperazione = await _context.Operazioni.FirstOrDefaultAsync(o => o.Id == id);

            if (existingOperazione == null)
            {
                return false;
            }

            existingOperazione.Funzionalita = operazione.Funzionalita;
            existingOperazione.Quantita = operazione.Quantita;
            existingOperazione.DataOperazione = operazione.DataOperazione;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteOperazioneAsync(int id)
        {
            var existingOperazione = await _context.Operazioni.FirstOrDefaultAsync(o => o.Id == id);

            if (existingOperazione == null)
            {
                return false;
            }

            _context.Operazioni.Remove(existingOperazione);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
