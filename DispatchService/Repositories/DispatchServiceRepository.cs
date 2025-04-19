using AutoMapper;
using DispatchService.Data;
using DispatchService.Dtos;
using DispatchService.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DispatchService.Repositories
{
    public class DispatchServiceRepository : ICrud<DispatchServiceResponseDto,DispatchServiceRequestDto>
    {
        public readonly DispatchServiceContext _context;
        public readonly IMapper _mapper;
        public DispatchServiceRepository(DispatchServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DispatchServiceResponseDto> AddAsync(DispatchServiceRequestDto entity)
        {
            var data =_mapper.Map<Dispatch>(entity);
            _context.Add(data);
            await _context.SaveChangesAsync();
            return _mapper.Map<DispatchServiceResponseDto>(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           bool result = false;
           var data = await  _context.CMPDispatch.FindAsync(id);
           _context.CMPDispatch.Remove(data);
           if (await _context.SaveChangesAsync() > 0)
                result = true;
            return result;
        }

        public async Task<IEnumerable<DispatchServiceResponseDto>> GetAllAsync()
        {
            var data = await _context.CMPDispatch.Include(da => da.DispatchAnexes).ToListAsync();
            return _mapper.Map<IEnumerable<DispatchServiceResponseDto>>(data);
        }

        public async Task<DispatchServiceResponseDto> GetByIdAsync(int id)
        {
            var data = await _context.CMPDispatch
                .Include(da => da.DispatchAnexes)
                .Where(d => d.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<DispatchServiceResponseDto>(data);
        }

        public async Task<DispatchServiceResponseDto> UpdateAsync(DispatchServiceResponseDto entity)
        {
            var data = _mapper.Map<Dispatch>(entity);
            _context.Update(data);
            await _context.SaveChangesAsync();
            return _mapper.Map<DispatchServiceResponseDto>(data);
        }
    }
}
