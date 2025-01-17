using AutoMapper;
using InvoicementTypeService.Dtos;
using InvoicementTypeService.Models;

namespace InvoicementTypeService
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile() {
            CreateMap<invoicementType, InvoicementTypeRequestDto>().ReverseMap();
            CreateMap<invoicementType,InvoicementTypeResponseDto>().ReverseMap();
            CreateMap<InvoicementTypeRequestDto, InvoicementTypeResponseDto>().ReverseMap();
       }
    }
}
