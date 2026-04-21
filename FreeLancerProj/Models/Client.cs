namespace FreeLancerProj.Models;

public class Client
{
    public int ClientId { get; set; }
    public string Name { get; set; } = default!;
    public double HourlyRate { get; set; }
    public string? Email { get; set; }

    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}