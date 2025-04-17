
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProfileService.Data;
using ProfileService.Dtos;

namespace ProfileService.Repositories
{
    public class ProfileServiceRepository : IprofileServiceRepository
    {
        private readonly ProfileContext _context;
        private readonly IMapper _mapper;
        public ProfileServiceRepository(ProfileContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProfileServiceResponseDto> AddAsync(ProfileServiceRequestDto entity)
        {
            var model = _mapper.Map<Models.Profile>(entity);
            _context.CmpProfiles.Add(model);
            await _context.SaveChangesAsync();
            var data = _mapper.Map<ProfileServiceResponseDto>(model);
            return data;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = false;
            var data = _context.CmpProfiles.Find(id);
            _context.CmpProfiles.Remove(data);
            if (await _context.SaveChangesAsync() > 0) {
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<ProfileServiceResponseDto>> GetAllAsync()
        {
            var data  = await _context.CmpProfiles.ToListAsync();
            return _mapper.Map<IEnumerable<ProfileServiceResponseDto>>(data);
        }

        public async Task<ProfileServiceResponseDto> GetByIdAsync(int id)
        {
            var data = await _context.CmpProfiles.FindAsync(id);
            return _mapper.Map<ProfileServiceResponseDto>(data);
        }

        public async Task<ProfileServiceResponseDto> UpdateAsync(ProfileServiceResponseDto entity)
        {
            var model = _mapper.Map<Models.Profile>(entity);
            _context.CmpProfiles.Update(model);
            await _context.SaveChangesAsync();
            var data = _mapper.Map<ProfileServiceResponseDto>(model);
            return data;
        }
    }
}
