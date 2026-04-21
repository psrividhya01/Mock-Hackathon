namespace FreeLancerProj.Models;

public class TaskItem
{
    public int TaskId { get; set; }
    public int ClientId { get; set; }
    public double Hours { get; set; }
    public string Description { get; set; } = default!;
    public TaskStatus Status { get; set; }   
    public int? InvoiceId { get; set; }

    public Client Client { get; set; } = default!;
    public Invoice? Invoice { get; set; }
}