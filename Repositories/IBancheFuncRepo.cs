using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancaApi.Repositories
{
    public interface IBancheFuncRepo
    {
        Task<IEnumerable<BancheFuncDto>> GetBancheFuncsAsync();
        Task<BancheFuncDto> GetBancheFuncByIdAsync(int id);
        Task<BancheFuncDto> AddBancheFuncAsync(BancheFuncDto bancheFuncDto);
        Task<bool> UpdateBancheFuncAsync(int id, BancheFuncDto bancheFuncDto);
        Task<bool> DeleteBancheFuncAsync(int id);
        Task<IEnumerable<Funzionalita>> GetFunzionalitaByBancaIdAsync(int idBanca);
        Task DeleteBancheFuncByBancaIdAsync(int idBanca);
        Task UpdateFunzionalitaByBancaIdAsync(int idBanca, List<FunzionalitaEntity> funzionalitaList);
        Task AddBancheFuncAsync1(BancheFuncDto bancheFuncDto);
    }
}
