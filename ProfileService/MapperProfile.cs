using AutoMapper;
using ProfileService.Dtos;
using ProfileService.Models;

namespace ProfileService
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile() {
            CreateMap<Models.Profile, ProfileServiceRequestDto>().ReverseMap();
            CreateMap<Models.Profile, ProfileServiceResponseDto>().ReverseMap();
            CreateMap<ProfileServiceResponseDto, ProfileServiceRequestDto>().ReverseMap();
        }
    }
        
}
