using AccountingconceptService.Dtos;
using AccountingconceptService.Models;
using AutoMapper;

namespace AccountingconceptService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
        
            CreateMap<AccountingConcept,AccountingConceptRequestDto>().ReverseMap();
            CreateMap<AccountingConcept, AccountingConceptResponseDto>().ReverseMap();
            CreateMap<AccountingConceptResponseDto, AccountingConceptRequestDto>().ReverseMap();
        }
    }
}
