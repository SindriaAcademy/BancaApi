using BancaApi.Entities;
using BancaApi.Models;

namespace BancaApi.Repositories
{
    public interface IContoRepository
    {
        Task<ContoEntity> GetContoByUtenteIdAsync(int idUtente);
        Task<IEnumerable<ContoEntity>> GetContiAsync();
        Task<ContoEntity> GetContoByIdAsync(int id);
        Task<ContoEntity> CreateContoAsync(ContoEntity conto);
        Task<bool> UpdateContoAsync(int id, ContoEntity conto);
        Task<bool> DeleteContoAsync(int id);
    }
}
