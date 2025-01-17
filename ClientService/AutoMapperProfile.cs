using AutoMapper;
using ClientService.Dto;
using ClientService.Models;

namespace ClientService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Client,ClientResponseDto>().ReverseMap();
            CreateMap<Client, ClientRequestDto>().ReverseMap();
        }  
    }
}
