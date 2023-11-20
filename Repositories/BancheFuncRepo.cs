using AutoMapper;
using BancaApi.DbContexts;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancaApi.Repositories
{
    public class BancheFuncRepo : IBancheFuncRepo
    {
        private readonly BancaInfoContext _context;
        private readonly IMapper _mapper;

        public BancheFuncRepo(BancaInfoContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<BancheFuncDto>> GetBancheFuncsAsync()
        {
            var bancheFuncs = await _context.BancheFunzionalita.ToListAsync();
            return _mapper.Map<List<BancheFuncDto>>(bancheFuncs);
        }

        public async Task<BancheFuncDto> GetBancheFuncByIdAsync(int id)
        {
            var bancheFunc = await _context.BancheFunzionalita.FindAsync(id);
            return _mapper.Map<BancheFuncDto>(bancheFunc);
        }

        public async Task<IEnumerable<Funzionalita>> GetFunzionalitaByBancaIdAsync(int idBanca)
        {
            var funzionalita = await _context.BancheFunzionalita
                .Where(bf => bf.IdBanca == idBanca)
                .Select(bf => new Funzionalita
                {
                    Id = bf.IdFunzionalita,
                    Nome = bf.Funzionalita.Nome
                })
                .ToListAsync();

            return funzionalita;
        }

        public async Task AddBancheFuncAsync1(BancheFuncDto bancheFuncDto)
        {
            var bancheFuncEntity = new BancheFunzionalitaEntity
            {
                IdBanca = bancheFuncDto.IdBanca,
                IdFunzionalita = bancheFuncDto.IdFunzionalita
            };

            await _context.BancheFunzionalita.AddAsync(bancheFuncEntity);
            await _context.SaveChangesAsync();
        }


        public async Task<BancheFuncDto> AddBancheFuncAsync(BancheFuncDto bancheFuncDto)
        {
            if (bancheFuncDto == null)
                throw new ArgumentNullException(nameof(bancheFuncDto));

            var bancheFuncEntity = _mapper.Map<BancheFunzionalitaEntity>(bancheFuncDto);

            _context.BancheFunzionalita.Add(bancheFuncEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<BancheFuncDto>(bancheFuncEntity);
        }

        public async Task<bool> UpdateBancheFuncAsync(int id, BancheFuncDto bancheFuncDto)
        {
            if (bancheFuncDto == null)
                throw new ArgumentNullException(nameof(bancheFuncDto));

            var existingBancheFunc = await _context.BancheFunzionalita.FindAsync(id);

            if (existingBancheFunc == null)
                return false;

            existingBancheFunc.IdBanca = bancheFuncDto.IdBanca;
            existingBancheFunc.IdFunzionalita = bancheFuncDto.IdFunzionalita;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateFunzionalitaByBancaIdAsync(int idBanca, List<FunzionalitaEntity> funzionalitaList)
        {
            await DeleteBancheFuncByBancaIdAsync(idBanca);

            foreach (var funzionalita in funzionalitaList)
            {
                var bancheFuncDto = new BancheFuncDto
                {
                    IdBanca = idBanca,
                    IdFunzionalita = funzionalita.Id
                };

                await AddBancheFuncAsync(bancheFuncDto);
            }
        }

        public async Task DeleteBancheFuncByBancaIdAsync(int idBanca)
        {
            try
            {
                var bancheFuncEntities = await _context.BancheFunzionalita
                    .Where(bf => bf.IdBanca == idBanca)
                    .ToListAsync();

                _context.BancheFunzionalita.RemoveRange(bancheFuncEntities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore durante l'eliminazione delle associazioni per l'ID banca {idBanca}. Dettagli: {ex.Message}");
            }
        }

        public async Task<bool> DeleteBancheFuncAsync(int id)
        {
            var bancheFunc = await _context.BancheFunzionalita.FindAsync(id);

            if (bancheFunc == null)
                return false;

            _context.BancheFunzionalita.Remove(bancheFunc);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
