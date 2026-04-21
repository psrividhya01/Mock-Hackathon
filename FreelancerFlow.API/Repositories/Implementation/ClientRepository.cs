using FreelancerFlow.API.Data;
using FreelancerFlow.API.Models;
using FreelancerFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreelancerFlow.API.Repositories.Implementation
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> AddClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetClientById(int id)
        {
            return await _context.Clients.FindAsync(id);
        }
    }
}
