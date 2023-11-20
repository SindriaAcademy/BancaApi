using AutoMapper;
using BancaApi.DbContexts;
using BancaApi.Dtos;
using BancaApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaApi.Repositories
{
    public class ContoRepository : IContoRepository
    {
        private readonly BancaInfoContext _context;
        private readonly IMapper _mapper;

        public ContoRepository(BancaInfoContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ContoDto> GetContoByUtenteIdAsync(int idUtente)
        {
            var contoEntity = await _context.Conti
                .FirstOrDefaultAsync(c => c.IdUtente == idUtente);

            return _mapper.Map<ContoDto>(contoEntity);
        }

        public async Task<IEnumerable<ContoDto>> GetContiAsync()
        {
            var contiEntities = await _context.Conti.ToListAsync();
            return _mapper.Map<IEnumerable<ContoDto>>(contiEntities);
        }

        public async Task<ContoDto> GetContoByIdAsync(int id)
        {
            var contoEntity = await _context.Conti
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<ContoDto>(contoEntity);
        }

        public async Task<ContoDto> CreateContoAsync(ContoDto contoDto)
        {
            if (contoDto == null)
            {
                throw new ArgumentNullException(nameof(contoDto));
            }

            var contoEntity = _mapper.Map<ContoEntity>(contoDto);

            _context.Conti.Add(contoEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ContoDto>(contoEntity);
        }

        public async Task<bool> UpdateContoAsync(int id, ContoDto contoDto)
        {
            if (contoDto == null)
            {
                throw new ArgumentNullException(nameof(contoDto));
            }

            var existingConto = await _context.Conti
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingConto == null)
            {
                return false;
            }

            // Update properties of the existing entity with new values from DTO
            existingConto.Saldo = contoDto.Saldo;
            existingConto.DataUltimaOperazione = contoDto.DataUltimaOperazione;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteContoAsync(int id)
        {
            var existingConto = await _context.Conti
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingConto == null)
            {
                return false;
            }

            _context.Conti.Remove(existingConto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
