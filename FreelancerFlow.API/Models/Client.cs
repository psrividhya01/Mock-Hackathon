namespace FreelancerFlow.API.Models
{
    public class Client
    {
        public int ClientId { get; set; }   // Primary Key

        public string Name { get; set; } = string.Empty;    // Client name

        public string? Email { get; set; }   // Client email (nullable)

        public double HourlyRate { get; set; } // Rate per hour - using double like old project
    }
}
