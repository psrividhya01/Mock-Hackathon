using FreelancerFlow.API.DTOs.Client;

namespace FreelancerFlow.API.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientResponseDto> CreateClient(CreateClientDto dto);
        Task<List<ClientResponseDto>> GetClients();

        
    }
}
