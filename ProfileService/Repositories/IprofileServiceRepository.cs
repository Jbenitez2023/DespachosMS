using Azure.Core;
using Azure;
using ProfileService.Dtos;

namespace ProfileService.Repositories
{
    public interface IprofileServiceRepository
    {
        Task<ProfileServiceResponseDto> AddAsync(ProfileServiceRequestDto entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProfileServiceResponseDto>> GetAllAsync();
        Task<ProfileServiceResponseDto> GetByIdAsync(int id);
        Task<ProfileServiceResponseDto> UpdateAsync(ProfileServiceResponseDto entity);
    }
}
