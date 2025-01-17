using AccountingconceptService.Dtos;

namespace AccountingconceptService.Repositories
{
    public interface IAccountingConceptRepository
    {
        public Task<IEnumerable<AccountingConceptResponseDto>> GetAll();
        public Task<AccountingConceptResponseDto> GetById(int id);
        public Task<AccountingConceptResponseDto> Create(AccountingConceptRequestDto dto);
        public Task<AccountingConceptResponseDto> Update(AccountingConceptResponseDto dto);
        public Task<bool> Delete(int id);
    }
}
