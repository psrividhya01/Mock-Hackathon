namespace FreelancerFlow.API.DTOs.Task
{
    public class TaskResponseDto
    {
        public int TaskId { get; set; }
        public int ClientId { get; set; }
        public int HoursWorked { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? InvoiceId { get; set; }
    }
}
