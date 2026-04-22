using FreelancerFlow.API.Models;

namespace FreelancerFlow.API.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice> AddInvoice(Invoice invoice);
        Task<List<Invoice>> GetAllInvoices();
        Task<Invoice?> GetInvoiceById(int id);
        Task UpdateInvoice(Invoice invoice);
        Task DeleteInvoice(int id);
    }
}
