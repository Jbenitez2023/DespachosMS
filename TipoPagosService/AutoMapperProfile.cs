using AutoMapper;
using TipoPagosService.Dto;
using TipoPagosService.Models;

namespace TipoPagosService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<PayType,PayTypeResponseDto>().ReverseMap();
            CreateMap<PayType, PayTypeRequestDto>().ReverseMap();
            CreateMap<PayTypeResponseDto, PayTypeRequestDto>().ReverseMap();
        }
    }
}
