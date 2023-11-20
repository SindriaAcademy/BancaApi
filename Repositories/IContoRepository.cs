using BancaApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancaApi.Repositories
{
    public interface IContoRepository
    {
        Task<ContoDto> GetContoByUtenteIdAsync(int idUtente);
        Task<IEnumerable<ContoDto>> GetContiAsync();
        Task<ContoDto> GetContoByIdAsync(int id);
        Task<ContoDto> CreateContoAsync(ContoDto conto);
        Task<bool> UpdateContoAsync(int id, ContoDto conto);
        Task<bool> DeleteContoAsync(int id);
    }
}
