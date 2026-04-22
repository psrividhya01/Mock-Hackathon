namespace FreelancerFlow.API.DTOs.Client
{
    public class ClientResponseDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public double HourlyRate { get; set; } // Using double
    }
}
