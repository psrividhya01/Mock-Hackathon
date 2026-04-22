using FreelancerFlow.API.DTOs.Client;
using FreelancerFlow.API.Models;
using FreelancerFlow.API.Repositories.Interfaces;
using FreelancerFlow.API.Services.Interfaces;

namespace FreelancerFlow.API.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClientResponseDto> CreateClient(CreateClientDto dto)
        {
            var client = new Client
            {
                Name = dto.Name,
                Email = dto.Email,
                HourlyRate = dto.HourlyRate
            };

            var result = await _repository.AddClient(client);

            return new ClientResponseDto
            {
                ClientId = result.ClientId,
                Name = result.Name,
                Email = result.Email,
                HourlyRate = result.HourlyRate
            };
        }

        public async Task<List<ClientResponseDto>> GetClients()
        {
            var clients = await _repository.GetAllClients();

            return clients.Select(c => new ClientResponseDto
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Email = c.Email,
                HourlyRate = c.HourlyRate
            }).ToList();
        }
    }
}
