using FreeLancerProj.Models;
using FreeLancerProj.Repositories.Interfaces;

namespace FreeLancerProj.Repositories.Implementations;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly AppDbContext _context;

    public InvoiceRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
    }

 
    public async Task<List<Invoice>> GetAllAsync()
    {
        return await _context.Invoices.ToListAsync();
    }

  
    public async Task<Invoice?> GetByIdAsync(int id)
    {
        return await _context.Invoices
            .FirstOrDefaultAsync(i => i.InvoiceId == id);
    }

    
    public async Task UpdateAsync(Invoice invoice)
    {
        _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync();
    }
}