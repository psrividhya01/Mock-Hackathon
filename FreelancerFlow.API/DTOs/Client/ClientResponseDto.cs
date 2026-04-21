namespace FreelancerFlow.API.DTOs.Client
{
    public class ClientResponseDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
    }
}
