using FreeLancerProj.DTOs;

namespace FreeLancerProj.Services.Interfaces;

public interface IInvoiceService 
{
    Task  <InvoiceDto?>GenerateInvoiceAsync(int clientId);
    Task <List<InvoiceDto>>GetAllInvoicesAsync();
    Task <InvoiceDto?> GetInvoiceByIdAsync(int invoiceId);
    Task <bool>MarkInvoiceAsPaidAsync(int invoiceId);
}