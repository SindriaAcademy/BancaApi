using BancaApi.Entities;
using BancaApi.Models;

namespace BancaApi.Repositories
{
    public interface IOperazioneRepository
    {
        Task<IEnumerable<OperazioneEntity>> GetOperazioniByUtenteIdAsync(int idUtente);
        Task<IEnumerable<OperazioneEntity>> GetOperazioniAsync();
        Task<OperazioneEntity> GetOperazioneByIdAsync(int id);
        Task<OperazioneEntity> CreateOperazioneAsync(OperazioneEntity operazione);
        Task<bool> UpdateOperazioneAsync(int id, OperazioneEntity operazione);
        Task<bool> DeleteOperazioneAsync(int id);
    }
}
