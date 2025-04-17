using UserService.Dtos;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        public Task<UserServiceResponseDto> GetById(int id);
        public Task<UserServiceResponseDto> GetByUser(string user,string password);
        public Task<IEnumerable<UserServiceResponseDto>> GetAsync();
        public Task<UserServiceResponseDto> Update(UserServiceResponseDto dto);
        public Task<UserServiceResponseDto> Create(UserServiceRequestDto dto);
        public Task<bool> Delete(int id);
    }
}
