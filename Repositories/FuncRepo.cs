using BancaApi.DbContexts;
using BancaApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancaApi.Repositories
{
    public class FuncRepo : IFuncRepo
    {
        private readonly BancaInfoContext _context;

        public FuncRepo(BancaInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<FunzionalitaEntity>> GetFuncsAsync()
        {
            return await _context.Funzionalita.ToListAsync();
        }

        public async Task<FunzionalitaEntity> GetFuncByIdAsync(int id)
        {
            return await _context.Funzionalita.FindAsync(id);
        }

        public async Task<FunzionalitaEntity> AddFuncAsync(FunzionalitaEntity func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            _context.Funzionalita.Add(func);
            await _context.SaveChangesAsync();

            return func;
        }

        public async Task<bool> UpdateFuncAsync(int id, FunzionalitaEntity func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            var existingFunc = await _context.Funzionalita.FindAsync(id);

            if (existingFunc == null)
            {
                return false;
            }

            existingFunc.Nome = func.Nome; // Aggiorna altri campi se necessario

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFuncAsync(int id)
        {
            var func = await _context.Funzionalita.FindAsync(id);

            if (func == null)
            {
                return false;
            }

            _context.Funzionalita.Remove(func);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
