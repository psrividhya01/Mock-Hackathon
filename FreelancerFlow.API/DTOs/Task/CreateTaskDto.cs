namespace FreelancerFlow.API.DTOs.Task
{
    public class CreateTaskDto
    {
        public int ClientId { get; set; }
        public int HoursWorked { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
