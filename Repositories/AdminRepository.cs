using AutoMapper;
using BancaApi.DbContexts;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancaApi.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly BancaInfoContext _context;
        private readonly IMapper _mapper;

        public AdminRepository(BancaInfoContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AdminDto>> GetAdminsAsync()
        {
            var admins = await _context.Admins.ToListAsync();
            return _mapper.Map<List<AdminDto>>(admins);
        }

        public async Task<AdminDto> GetAdminByIdAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            return _mapper.Map<AdminDto>(admin);
        }

        public async Task<AdminDto> AddAdminAsync(AdminDto adminDto)
        {
            if (adminDto == null)
                throw new ArgumentNullException(nameof(adminDto));

            adminDto.Password = PasswordHasher.HashPassword(adminDto.Password);
            var adminEntity = _mapper.Map<AdminEntity>(adminDto);

            _context.Admins.Add(adminEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<AdminDto>(adminEntity);
        }

        public async Task<bool> UpdateAdminAsync(int id, AdminDto adminDto)
        {
            if (adminDto == null)
                throw new ArgumentNullException(nameof(adminDto));

            var existingAdmin = await _context.Admins.FindAsync(id);

            if (existingAdmin == null)
                return false;

            existingAdmin.Username = adminDto.Username;
            existingAdmin.Password = adminDto.Password;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAdminAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
                return false;

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
