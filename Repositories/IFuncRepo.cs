using BancaApi.Entities;

namespace BancaApi.Repositories
{
    public interface IFuncRepo
    {
        Task<IEnumerable<FunzionalitaEntity>> GetFuncsAsync();
        Task<FunzionalitaEntity> GetFuncByIdAsync(int id);
        Task<FunzionalitaEntity> AddFuncAsync(FunzionalitaEntity func);
        Task<bool> UpdateFuncAsync(int id, FunzionalitaEntity func);
        Task<bool> DeleteFuncAsync(int id);
    }
}
