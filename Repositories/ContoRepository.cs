using BancaApi.DbContexts;
using BancaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancaApi.Repositories
{
    public class ContoRepository : IContoRepository
    {
        private readonly BancaInfoContext _context;

        public ContoRepository(BancaInfoContext context)
        {
            _context = context;
        }

        public async Task<ContoEntity> GetContoByUtenteIdAsync(int idUtente)
        {
            return await _context.Conti.FirstOrDefaultAsync(conto => conto.IdUtente == idUtente);
        }

        public async Task<IEnumerable<ContoEntity>> GetContiAsync()
        {
            return await _context.Conti.ToListAsync();
        }

        public async Task<ContoEntity> GetContoByIdAsync(int id)
        {
            return await _context.Conti.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ContoEntity> CreateContoAsync(ContoEntity conto)
        {
            if (conto == null)
            {
                throw new ArgumentNullException(nameof(conto));
            }

            _context.Conti.Add(conto);
            await _context.SaveChangesAsync();

            return conto;
        }

        public async Task<bool> UpdateContoAsync(int id, ContoEntity conto)
        {
            if (conto == null)
            {
                throw new ArgumentNullException(nameof(conto));
            }

            var existingConto = await _context.Conti.FirstOrDefaultAsync(c => c.Id == id);

            if (existingConto == null)
            {
                return false;
            }

            existingConto.IdUtente = conto.IdUtente;
            existingConto.Saldo = conto.Saldo;
            existingConto.DataUltimaOperazione = conto.DataUltimaOperazione;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteContoAsync(int id)
        {
            var existingConto = await _context.Conti.FirstOrDefaultAsync(c => c.Id == id);

            if (existingConto == null)
            {
                return false;
            }

            _context.Conti.Remove(existingConto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
