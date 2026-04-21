using FreeLancerProj.Enums;

namespace FreeLancerProj.DTOs;

public class InvoiceDto
{
    public int InvoiceId { get; set; }
    public int ClientId { get; set; }
    public double TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public InvoiceStatus Status { get; set; }
}