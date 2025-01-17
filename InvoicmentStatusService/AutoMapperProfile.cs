using AutoMapper;
using InvoicmentStatusService.Dtos;
using InvoicmentStatusService.Models;

namespace InvoicmentStatusService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<InvoicementStatus,InvoicementStatusResponseDto>().ReverseMap();
            CreateMap<InvoicementStatus, InvoicementStatusRequestDto>().ReverseMap();
            CreateMap<InvoicementStatusRequestDto, InvoicementStatusResponseDto>().ReverseMap();
        }
    }
}
