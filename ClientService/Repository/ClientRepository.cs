using AutoMapper;
using ClientService.Data;
using ClientService.Dto;
using ClientService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _context;
        private readonly IMapper _mapper;
        public ClientRepository(ClientContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ClientResponseDto> Create(Client client)
        {
            if (client == null) {throw new Exception("Error al recibir el cliente");}
            _context.CmpClients.Add(client);
            await _context.SaveChangesAsync();

           return _mapper.Map<ClientResponseDto>(client);

        }
        public async Task<int> Delete(int id)
        {

            Client client = _context.CmpClients.Find(id);
            if (client == null) { throw new Exception("Error al encontrar el cliente"); }
            _context.CmpClients.Remove(client);
            return await _context.SaveChangesAsync(); 
        }
        public async Task<IEnumerable<ClientResponseDto>> GetAll()
        {
            var clientList = await _context.CmpClients.ToListAsync();
            return _mapper.Map<List<ClientResponseDto>>(clientList);
        }
        public async Task<ClientResponseDto> GetById(int id)
        {
            var client = await _context.CmpClients.FindAsync(id);
            return _mapper.Map<ClientResponseDto>(client);
        }
        public async Task<ClientResponseDto> Update(Client client)
        {
            if (client == null) { throw new Exception("Error al recibir el cliente"); }
            _context.CmpClients.Update(client);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClientResponseDto>(client);
        }
    }
}
