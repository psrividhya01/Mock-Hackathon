namespace FreelancerFlow.API.DTOs.Client
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double HourlyRate { get; set; }
        public string? Email { get; set; }
    }
}
