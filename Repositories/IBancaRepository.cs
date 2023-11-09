using BancaApi.Entities;
using BancaApi.Models;

namespace BancaApi.Repositories
{
    public interface IBancaRepository
    {
        Task<IEnumerable<BancaEntity>> GetBancheAsync();
        Task<BancaEntity> GetBancaByIdAsync(int id);
        Task<BancaEntity> CreateBancaAsync(BancaEntity banca);
        Task<bool> UpdateBancaAsync(int id, BancaEntity banca);
        Task<bool> DeleteBancaAsync(int id);
    }
}
