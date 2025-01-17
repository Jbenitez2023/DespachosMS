using AccountingconceptService.Data;
using AccountingconceptService.Dtos;
using AccountingconceptService.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountingconceptService.Repositories
{
    public class AccountingConceptRepository : IAccountingConceptRepository
    {
        private readonly AccountingConceptContext _context;
        private readonly IMapper _mapper;

        public AccountingConceptRepository(AccountingConceptContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountingConceptResponseDto> Create(AccountingConceptRequestDto dto)
        {
            var data = _mapper.Map<AccountingConcept>(dto);
            _context.CMPAccountingConcept.Add(data);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountingConceptResponseDto>(data);
        }

        public async Task<bool> Delete(int id)
        {
            var result = false;
            var data = await _context.CMPAccountingConcept.FindAsync(id);
            _context.CMPAccountingConcept.Remove(data);
            if (await _context.SaveChangesAsync() > 0) { 
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<AccountingConceptResponseDto>> GetAll()
        {
            var data = await _context.CMPAccountingConcept.ToListAsync();
            return _mapper.Map<IEnumerable<AccountingConceptResponseDto>>(data);
        }

        public async Task<AccountingConceptResponseDto> GetById(int id)
        {
            var data = await _context.CMPAccountingConcept.ToListAsync();
            return _mapper.Map<AccountingConceptResponseDto>(data);
        }

        public async Task<AccountingConceptResponseDto> Update(AccountingConceptResponseDto dto)
        {
            var data = _mapper.Map<AccountingConcept>(dto);
            _context.CMPAccountingConcept.Update(data);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountingConceptResponseDto>(data);
        }
    }
}
