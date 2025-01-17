using OperationTypeService.Dto;
using OperationTypeService.Models;

namespace OperationTypeService.Repositories
{
    public interface IOperationTypeRepository
    {
        public Task<IEnumerable<OperationTypeResponseDto>> GetAll();
        public Task<OperationTypeResponseDto> GetById(int id);
        public Task<OperationTypeResponseDto> Update(OperationTypeResponseDto model);
        public Task<bool> DeleteById(int id);
        public Task<OperationTypeResponseDto> Create(OperationTyperequestDto model);
    }
}
