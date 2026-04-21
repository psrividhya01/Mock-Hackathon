using FreeLancerProj.Models;

namespace FreeLancerProj.Repositories.Interfaces;

public interface IInvoiceRepository
{
    Task AddAsync(Invoice invoice);

    Task<List<Invoice>> GetAllAsync();

    Task<Invoice?> GetByIdAsync(int id);

    Task UpdateAsync(Invoice invoice);
}