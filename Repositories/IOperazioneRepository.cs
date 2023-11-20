using BancaApi.Dtos;

namespace BancaApi.Repositories
{
    public interface IOperazioneRepository
    {
        Task<IEnumerable<OperazioneDto>> GetOperazioniByUtenteIdAsync(int idUtente);
        Task<IEnumerable<OperazioneDto>> GetOperazioniAsync();
        Task<OperazioneDto> GetOperazioneByIdAsync(int id);
        Task<OperazioneDto> CreateOperazioneAsync(OperazioneDto operazioneDto);
        Task<bool> UpdateOperazioneAsync(int id, OperazioneDto operazioneDto);
        Task<bool> DeleteOperazioneAsync(int id);
    }
}
