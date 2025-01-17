using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TipoPagosService.Data;
using TipoPagosService.Dto;
using TipoPagosService.Models;

namespace TipoPagosService.Repositories
{
    public class PayTypeRepository : IPayTypeRepository
    {
        public readonly PayTypeContext _PayTypeContext;
        public readonly IMapper _mapper;

        public PayTypeRepository(PayTypeContext payTypeContext, IMapper mapper)
        {
            _PayTypeContext = payTypeContext;
            _mapper = mapper;
        }
        public async Task<PayTypeResponseDto> Create(PayTypeRequestDto Model)
        {
            var data =_mapper.Map<PayType>(Model);
             _PayTypeContext.CmpTypePay.Add(data);
            await _PayTypeContext.SaveChangesAsync();
            return _mapper.Map<PayTypeResponseDto>(data);
        }
        public async Task<bool> Delete(int id)
        {
            var result = false;
            var data = _PayTypeContext.CmpTypePay.Find(id);
            _PayTypeContext.Remove(data);
            if (await _PayTypeContext.SaveChangesAsync() > 0) {
                result = true;
            }

            return result;
        }
        public async Task<IEnumerable<PayTypeResponseDto>> Getall()
        {
            var lista = await _PayTypeContext.CmpTypePay.ToListAsync();
            return _mapper.Map<IEnumerable<PayTypeResponseDto>>(lista);
        }
        public async Task<PayTypeResponseDto> GetByid(int id)
        {
            var data = await _PayTypeContext.CmpTypePay.FindAsync(id);
            return _mapper.Map<PayTypeResponseDto>(data);
        }
        public async Task<PayTypeResponseDto> Update(PayTypeResponseDto Model)
        {
            var data = _mapper.Map<PayType>(Model);
            _PayTypeContext.CmpTypePay.Update(data);
            await _PayTypeContext.SaveChangesAsync();
            return _mapper.Map<PayTypeResponseDto>(data);
        }
    }
}
