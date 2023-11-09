using BancaApi.DbContexts;
using BancaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancaApi.Repositories
{
    public class BancaRepository : IBancaRepository
    {
        private readonly BancaInfoContext _context;

        public BancaRepository(BancaInfoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BancaEntity>> GetBancheAsync()
        {
            return await _context.Banche.ToListAsync();
        }

        public async Task<BancaEntity> GetBancaByIdAsync(int id)
        {
            return await _context.Banche.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BancaEntity> CreateBancaAsync(BancaEntity banca)
        {
            if (banca == null)
            {
                throw new ArgumentNullException(nameof(banca));
            }

            _context.Banche.Add(banca);
            await _context.SaveChangesAsync();

            return banca;
        }

        public async Task<bool> UpdateBancaAsync(int id, BancaEntity banca)
        {
            if (banca == null)
            {
                throw new ArgumentNullException(nameof(banca));
            }

            var existingBanca = await _context.Banche.FirstOrDefaultAsync(b => b.Id == id);

            if (existingBanca == null)
            {
                return false;
            }

            existingBanca.Nome = banca.Nome;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBancaAsync(int id)
        {
            var existingBanca = await _context.Banche.FirstOrDefaultAsync(b => b.Id == id);

            if (existingBanca == null)
            {
                return false;
            }

            _context.Banche.Remove(existingBanca);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
