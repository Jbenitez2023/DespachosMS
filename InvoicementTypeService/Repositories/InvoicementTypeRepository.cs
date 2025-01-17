using AutoMapper;
using InvoicementTypeService.Data;
using InvoicementTypeService.Dtos;
using InvoicementTypeService.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicementTypeService.Repositories
{
    public class InvoicementTypeRepository : IInvoicementTypeRepository
    {
        private readonly invoicementTypeContext _invoicementTypeContext;
        private readonly IMapper _mapper;

        public InvoicementTypeRepository(invoicementTypeContext invoicementTypeContext, IMapper mapper)
        {
            _invoicementTypeContext = invoicementTypeContext;
            _mapper = mapper;
        }

        public async Task<InvoicementTypeResponseDto> Create(InvoicementTypeRequestDto dto)
        {
            var data = _mapper.Map<invoicementType>(dto);
            _invoicementTypeContext.CmpInvoicementTypes.Add(data);
            await _invoicementTypeContext.SaveChangesAsync();
            return _mapper.Map<InvoicementTypeResponseDto>(data);

        }

        public async Task<bool> DeleteById(int id)
        {
            var result = false;
            var data = await _invoicementTypeContext.CmpInvoicementTypes.FindAsync(id);
            _invoicementTypeContext.CmpInvoicementTypes.Remove(data);
            var deleted = await  _invoicementTypeContext.SaveChangesAsync();
            if (deleted > 0)
                result = true;
            return result;
        }

        public async Task<IEnumerable<InvoicementTypeResponseDto>> GetAll()
        {
            var data = await _invoicementTypeContext.CmpInvoicementTypes.ToListAsync();
            return _mapper.Map<IEnumerable<InvoicementTypeResponseDto>>(data);
        }

        public async Task<InvoicementTypeResponseDto> GetById(int id)
        {
            var data = await _invoicementTypeContext.CmpInvoicementTypes.FindAsync(id);
            return _mapper.Map<InvoicementTypeResponseDto>(data);
        }

        public async Task<InvoicementTypeResponseDto> Update(InvoicementTypeResponseDto dto)
        {
            var data = _mapper.Map<invoicementType>(dto);
            _invoicementTypeContext.CmpInvoicementTypes.Update(data);
            await _invoicementTypeContext.SaveChangesAsync();
            return _mapper.Map<InvoicementTypeResponseDto>(data);
        }
    }
}
