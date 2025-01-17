using TipoPagosService.Dto;

namespace TipoPagosService.Repositories
{
    public interface IPayTypeRepository
    {
        public Task<IEnumerable<PayTypeResponseDto>> Getall();
        public Task<PayTypeResponseDto> GetByid(int id);
        public Task<PayTypeResponseDto> Create(PayTypeRequestDto Model);
        public Task<PayTypeResponseDto> Update(PayTypeResponseDto Model);
        public Task<bool> Delete(int id);
    }
}
