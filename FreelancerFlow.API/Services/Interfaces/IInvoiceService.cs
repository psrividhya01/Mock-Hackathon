using FreelancerFlow.API.Models;

namespace FreelancerFlow.API.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> GenerateInvoice(int clientId);
        Task<List<Invoice>> GetInvoices();
        Task<Invoice?> GetInvoiceById(int id);
        Task MarkAsPaid(int id);
    }
}
