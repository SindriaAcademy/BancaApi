using AutoMapper;
using BancaApi.DbContexts;
using BancaApi.Dtos;
using BancaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancaApi.Repositories
{
    public class OperazioneRepository : IOperazioneRepository
    {
        private readonly BancaInfoContext _context;
        private readonly IMapper _mapper;

        public OperazioneRepository(BancaInfoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OperazioneDto>> GetOperazioniByUtenteIdAsync(int idUtente)
        {
            var operazioni = await _context.Operazioni
                .Where(operazione => operazione.IdUtente == idUtente)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OperazioneDto>>(operazioni);
        }

        public async Task<IEnumerable<OperazioneDto>> GetOperazioniAsync()
        {
            var operazioni = await _context.Operazioni.ToListAsync();
            return _mapper.Map<IEnumerable<OperazioneDto>>(operazioni);
        }

        public async Task<OperazioneDto> GetOperazioneByIdAsync(int id)
        {
            var operazione = await _context.Operazioni.FirstOrDefaultAsync(o => o.Id == id);
            return _mapper.Map<OperazioneDto>(operazione);
        }

        public async Task<OperazioneDto> CreateOperazioneAsync(OperazioneDto operazioneDto)
        {
            if (operazioneDto == null)
            {
                throw new ArgumentNullException(nameof(operazioneDto));
            }

            var operazioneEntity = _mapper.Map<OperazioneEntity>(operazioneDto);

            _context.Operazioni.Add(operazioneEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<OperazioneDto>(operazioneEntity);
        }

        public async Task<bool> UpdateOperazioneAsync(int id, OperazioneDto operazioneDto)
        {
            if (operazioneDto == null)
            {
                throw new ArgumentNullException(nameof(operazioneDto));
            }

            var existingOperazione = await _context.Operazioni.FirstOrDefaultAsync(o => o.Id == id);

            if (existingOperazione == null)
            {
                return false;
            }

            _mapper.Map(operazioneDto, existingOperazione);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteOperazioneAsync(int id)
        {
            var existingOperazione = await _context.Operazioni.FirstOrDefaultAsync(o => o.Id == id);

            if (existingOperazione == null)
            {
                return false;
            }

            _context.Operazioni.Remove(existingOperazione);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
