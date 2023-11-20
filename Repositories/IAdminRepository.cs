using BancaApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancaApi.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<AdminDto>> GetAdminsAsync();
        Task<AdminDto> GetAdminByIdAsync(int id);
        Task<AdminDto> AddAdminAsync(AdminDto adminDto);
        Task<bool> UpdateAdminAsync(int id, AdminDto adminDto);
        Task<bool> DeleteAdminAsync(int id);
    }
}
