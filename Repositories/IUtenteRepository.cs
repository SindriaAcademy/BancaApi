using BancaApi.Entities;
using BancaApi.Models;

namespace BancaApi.Repositories
{
    public interface IUtenteRepository
    {
        Task<IEnumerable<UtenteEntity>> GetUtentiAsync();
        Task<UtenteEntity> GetUtenteByIdAsync(int id);
        Task<UtenteEntity> CreateUtenteAsync(UtenteEntity utente);
        Task<bool> UpdateUtenteAsync(int id, UtenteEntity utente);
        Task<bool> DeleteUtenteAsync(int id);
    }
}
