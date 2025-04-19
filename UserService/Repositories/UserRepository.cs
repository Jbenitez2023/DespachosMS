using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserServiceContext _Context { get; set; }
        public IMapper _Mapper { get; set; }

        public UserRepository(UserServiceContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<UserServiceResponseDto> Create(UserServiceRequestDto dto)
        {
            var data = _Mapper.Map<User>(dto);
            _Context.CmpUsers.Add(data);
            await _Context.SaveChangesAsync();
            return _Mapper.Map<UserServiceResponseDto>(data);
        }

        public async Task<bool> Delete(int id)
        {
            var result = false;

            var data = _Context.CmpUsers.Find(id);
            _Context.CmpUsers.Remove(data);
            if(await _Context.SaveChangesAsync() > 0)
                result = true;

            return result;
        }

        public async Task<IEnumerable<UserServiceResponseDto>> GetAsync()
        {
            var data = await _Context.CmpUsers.ToListAsync();
            return _Mapper.Map<IEnumerable<UserServiceResponseDto>>(data);
        }

        public async Task<UserServiceResponseDto> GetById(int id)
        {
            var data = await _Context.CmpUsers.FindAsync(id);
            return _Mapper.Map<UserServiceResponseDto>(data);
        }

        public async Task<UserServiceResponseDto> Update(UserServiceResponseDto dto)
        {
            var data = _Mapper.Map<User>(dto);
            _Context.CmpUsers.Update(data);
            await _Context.SaveChangesAsync();
            return _Mapper.Map<UserServiceResponseDto>(data);
        }

        public async Task<UserServiceResponseDto> GetByUser(string user, string password)
        {
            var data = await _Context.CmpUsers.Where(us => us.UserName == user && us.Password == password).FirstOrDefaultAsync();
            return _Mapper.Map<UserServiceResponseDto>(data);
        }
    }
}
