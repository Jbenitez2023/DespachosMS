using InvoicmentStatusService.Dtos;
using InvoicmentStatusService.Models;

namespace InvoicmentStatusService.Repositories
{
    public interface IInvoicementStatusRepository
    {
        public Task<IEnumerable<InvoicementStatusResponseDto>> GetAll();
        public Task<InvoicementStatusResponseDto> GetById(int id);
        public Task<InvoicementStatusResponseDto> Create(InvoicementStatusRequestDto Model);
        public Task<InvoicementStatusResponseDto> Update(InvoicementStatusResponseDto Model);
        public Task<bool> Delete(int id);
    }
}
