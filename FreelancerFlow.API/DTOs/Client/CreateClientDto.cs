namespace FreelancerFlow.API.DTOs.Client
{
    public class CreateClientDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public double HourlyRate { get; set; } // Using double
    }
}
