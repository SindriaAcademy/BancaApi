using BancaApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancaApi.Repositories
{
    public interface IUtenteRepository
    {
        Task<IEnumerable<UtenteDto>> GetUtentiAsync();
        Task<UtenteDto> GetUtenteByIdAsync(int id);
        Task<UtenteDto> CreateUtenteAsync(UtenteDto utenteDto);
        Task<bool> UpdateUtenteAsync(int id, UtenteDto utenteDto);
        Task<bool> DeleteUtenteAsync(int id);
        Task<IEnumerable<UtenteDto>> GetUtentiByBancaIdAsync(int idBanca);
    }
}
