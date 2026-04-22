using FreelancerFlow.API.Data;
using FreelancerFlow.API.Models;
using FreelancerFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreelancerFlow.API.Repositories.Implementation
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await _context.Invoices.Include(i => i.Client).ToListAsync();
        }

        public async Task<Invoice?> GetInvoiceById(int id)
        {
            return await _context.Invoices.Include(i => i.Client).FirstOrDefaultAsync(i => i.InvoiceId == id);
        }

        public async Task UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
