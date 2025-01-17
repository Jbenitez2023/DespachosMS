using InvoicementTypeService.Dtos;

namespace InvoicementTypeService.Repositories
{
    public interface IInvoicementTypeRepository
    {
        public Task<IEnumerable<InvoicementTypeResponseDto>> GetAll();
        public Task<InvoicementTypeResponseDto> GetById(int id);
        public Task<InvoicementTypeResponseDto> Create(InvoicementTypeRequestDto dto);
        public Task<InvoicementTypeResponseDto> Update(InvoicementTypeResponseDto dto);
        public Task<bool> DeleteById(int id);
    }
}
