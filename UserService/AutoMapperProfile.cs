using AutoMapper;
using UserService.Dtos;
using UserService.Models;

namespace UserService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<User, UserServiceResponseDto>().ReverseMap();
            CreateMap<User, UserServiceRequestDto>().ReverseMap();
            CreateMap<UserServiceResponseDto, UserServiceRequestDto>().ReverseMap();
            CreateMap<User, UserValidationDto>().ReverseMap();
        }
    }
}
