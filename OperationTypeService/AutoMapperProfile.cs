using AutoMapper;
using OperationTypeService.Dto;
using OperationTypeService.Models;

namespace OperationTypeService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OperationType, OperationTypeResponseDto>().ReverseMap();
            CreateMap<OperationType, OperationTyperequestDto>().ReverseMap();
            CreateMap<OperationTypeResponseDto, OperationTyperequestDto>().ReverseMap();
        }
    }
}
