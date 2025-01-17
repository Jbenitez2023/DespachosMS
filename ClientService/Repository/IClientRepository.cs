using ClientService.Dto;
using ClientService.Models;

namespace ClientService.Repository
{
    public interface IClientRepository
    {
        public Task<IEnumerable<ClientResponseDto>> GetAll();
        public Task<ClientResponseDto> GetById(int id);
        public Task<ClientResponseDto> Update(Client client);
        public Task<ClientResponseDto> Create(Client client);
        public Task<int> Delete(int id);
    }
}
