using FreelancerFlow.API.Models;

namespace FreelancerFlow.API.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> AddClient(Client client);
        Task<List<Client>> GetAllClients();
        Task<Client?> GetClientById(int id);
    }
}
