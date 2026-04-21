namespace FreeLancerProj.DTOs;

public class TaskDto
{
    public int TaskId { get; set; }
    public int ClientId { get; set; }
    public double Hours { get; set; }
    public string Description { get; set; } = default!;
    public string Status { get; set; } = default!;
     public int? InvoiceId { get; set; }
     
}