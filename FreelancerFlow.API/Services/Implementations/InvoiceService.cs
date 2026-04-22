using FreelancerFlow.API.Data;
using FreelancerFlow.API.Enums;
using FreelancerFlow.API.Models;
using FreelancerFlow.API.Repositories.Interfaces;
using FreelancerFlow.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreelancerFlow.API.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly AppDbContext _context;

        public InvoiceService(IInvoiceRepository invoiceRepository, IClientRepository clientRepository, ITaskRepository taskRepository, AppDbContext context)
        {
            _invoiceRepository = invoiceRepository;
            _clientRepository = clientRepository;
            _taskRepository = taskRepository;
            _context = context;
        }

        public async Task<Invoice> GenerateInvoice(int clientId)
        {
            var client = await _clientRepository.GetClientById(clientId);
            if (client == null) throw new Exception("Client not found");

            var unbilledTasks = await _context.TaskItems
                .Where(t => t.ClientId == clientId && t.Status == TaskItemStatus.UnBilled)
                .ToListAsync();

            if (!unbilledTasks.Any()) throw new Exception("No unbilled tasks");

            double totalAmount = unbilledTasks.Sum(t => t.HoursWorked * client.HourlyRate);

            var invoice = new Invoice
            {
                ClientId = clientId,
                TotalAmount = totalAmount,
                Status = InvoiceStatus.Unpaid,
                CreatedAt = DateTime.UtcNow
            };

            await _invoiceRepository.AddInvoice(invoice);

            foreach (var task in unbilledTasks)
            {
                task.Status = TaskItemStatus.Billed;
                task.InvoiceId = invoice.InvoiceId;
            }

            await _context.SaveChangesAsync();

            return invoice;
        }

        public async Task<List<Invoice>> GetInvoices()
        {
            return await _invoiceRepository.GetAllInvoices();
        }

        public async Task<Invoice?> GetInvoiceById(int id)
        {
            return await _invoiceRepository.GetInvoiceById(id);
        }

        public async Task MarkAsPaid(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceById(id);
            if (invoice != null)
            {
                invoice.Status = InvoiceStatus.Paid;
                await _invoiceRepository.UpdateInvoice(invoice);
            }
        }
    }
}
