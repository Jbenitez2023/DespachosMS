using AutoMapper;
using InvoicmentStatusService.Data;
using InvoicmentStatusService.Dtos;
using InvoicmentStatusService.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicmentStatusService.Repositories
{
    public class InvoicementStatusRepository : IInvoicementStatusRepository
    {
        private readonly InvoicementStatusContext _context;
        private readonly IMapper _mapper;

        public InvoicementStatusRepository(InvoicementStatusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvoicementStatusResponseDto> Create(InvoicementStatusRequestDto Model)
        {
            var data = _mapper.Map<InvoicementStatus>(Model);
            _context.CmpInvoicementStatus.Add(data);
            await  _context.SaveChangesAsync();
            return _mapper.Map<InvoicementStatusResponseDto>(data);
        }

        public async Task<bool> Delete(int id)
        {
            bool result = false;
            var data = await  _context.CmpInvoicementStatus.FindAsync(id);
            _context.CmpInvoicementStatus.Remove(data);
            var removed = await  _context.SaveChangesAsync();
            if (removed > 0) {
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<InvoicementStatusResponseDto>> GetAll()
        {
            var data =  await _context.CmpInvoicementStatus.ToListAsync();
            return _mapper.Map<IEnumerable<InvoicementStatusResponseDto>>(data);
        }

        public async Task<InvoicementStatusResponseDto> GetById(int id)
        {
            var data = await _context.CmpInvoicementStatus.FindAsync(id);
            return _mapper.Map<InvoicementStatusResponseDto>(data);
        }

        public async Task<InvoicementStatusResponseDto> Update(InvoicementStatusResponseDto Model)
        {
            var data = _mapper.Map<InvoicementStatus>(Model);
            _context.CmpInvoicementStatus.Update(data);
            await _context.SaveChangesAsync();
            return _mapper.Map<InvoicementStatusResponseDto>(data);
        }
    }
}
