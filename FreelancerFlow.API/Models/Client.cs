namespace FreelancerFlow.API.Models
{
    public class Client
    {
        public int ClientId { get; set; }   // Primary Key

        public string Name { get; set; }    // Client name

        public string Email { get; set; }   // Client email

        public decimal HourlyRate { get; set; } // Rate per hour
    }
}
