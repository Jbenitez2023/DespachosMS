using AutoMapper;
using DispatchService.Dtos;
using DispatchService.Models;

namespace DispatchService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Dispatch,DispatchServiceRequestDto>()
                .ForMember(dest => dest.dispatchAnnexesDtos, opt => opt.MapFrom(src => src.DispatchAnexes))
                .ReverseMap();
            CreateMap<Dispatch, DispatchServiceResponseDto>()
                .ForMember(dest => dest.dispatchAnnexesDtos, opt => opt.MapFrom(src => src.DispatchAnexes))
                .ReverseMap();
            CreateMap<DispatchServiceResponseDto, DispatchServiceRequestDto>().ReverseMap();
            CreateMap<DispatchAnnexes, DispatchAnnexesDto>().ReverseMap();
        }
    }
}
