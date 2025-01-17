using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationTypeService.Data;
using OperationTypeService.Dto;
using OperationTypeService.Models;

namespace OperationTypeService.Repositories
{
    public class OperationTypeRepository : IOperationTypeRepository
    {
        private readonly OperationTypeContext _Context;
        private readonly IMapper _Mapper;

        public OperationTypeRepository(OperationTypeContext operationTypeContext,IMapper mapper)
        {
            _Context = operationTypeContext;
            _Mapper = mapper;
        }
        public async Task<OperationTypeResponseDto> Create(OperationTyperequestDto model)
        {
            var data = _Mapper.Map<OperationType>(model);
            _Context.CmpOperationTypes.Add(data); 
             await _Context.SaveChangesAsync();
            return _Mapper.Map<OperationTypeResponseDto>(model);
        }
        public async Task<bool> DeleteById(int id)
        {
            bool result = false;
            var data = await _Context.CmpOperationTypes.FindAsync(id);
            _Context.CmpOperationTypes.Remove(data);
            if( await _Context.SaveChangesAsync() > 0) { result = true; }

            return result;
        }
        public async Task<IEnumerable<OperationTypeResponseDto>> GetAll()
        {
            var lista = await _Context.CmpOperationTypes.ToListAsync();
            return _Mapper.Map<IEnumerable<OperationTypeResponseDto>>(lista);
        }
        public async Task<OperationTypeResponseDto> GetById(int id)
        {
            var data = await _Context.CmpOperationTypes.FindAsync(id);
            return _Mapper.Map<OperationTypeResponseDto>(data);
        }
        public async Task<OperationTypeResponseDto> Update(OperationTypeResponseDto model)
        {
            var data = _Mapper.Map<OperationType>(model);
            _Context.CmpOperationTypes.Update(data);
            await _Context.SaveChangesAsync();
            return _Mapper.Map<OperationTypeResponseDto>(model);
        }
    }
}
