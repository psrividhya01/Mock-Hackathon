using FreeLancerProj.DTOs;
using FreeLancerProj.Models;
using FreeLancerProj.Repositories.Interfaces;
using FreeLancerProj.Enums;
using TaskStatus = FreeLancerProj.Enums.TaskStatus;

namespace FreeLancerProj.Services.Implementations;
using FreeLancerProj.Services.Interfaces;
public class InvoiceService : IInvoiceService
{
     private readonly IInvoiceRepository _invoiceRepo;
    private readonly ITaskRepository _taskRepo;
    private readonly IClientRepository _clientRepo;

    public InvoiceService(
        IInvoiceRepository invoiceRepo,
        ITaskRepository taskRepo,
        IClientRepository clientRepo)
    {
        _invoiceRepo = invoiceRepo;
        _taskRepo = taskRepo;
        _clientRepo = clientRepo;
    }

  
    public async Task<InvoiceDto?> GenerateInvoiceAsync(int clientId)
    {
        var tasks = await _taskRepo.GetUnbilledTasksByClientAsync(clientId);

        if (tasks == null || !tasks.Any())
            return null;

        var client = await _clientRepo.GetByIdAsync(clientId);
        if (client == null)
            return null;

        double total = tasks.Sum(t => t.Hours * client.HourlyRate);

        var invoice = new Invoice
        {
            ClientId = clientId,
            TotalAmount = total,
            Status = InvoiceStatus.Unpaid,   
            CreatedAt = DateTime.UtcNow
        };

        await _invoiceRepo.AddAsync(invoice);

        
        foreach (var task in tasks)
        {
            task.InvoiceId = invoice.InvoiceId;
            task.Status = TaskStatus.Billed;   
        }

        await _taskRepo.UpdateRangeAsync(tasks);

        return new InvoiceDto
        {
            InvoiceId = invoice.InvoiceId,
            ClientId = invoice.ClientId,
            TotalAmount = invoice.TotalAmount,
            Status = invoice.Status
        };
    }

   
    public async Task<List<InvoiceDto>> GetAllInvoicesAsync()
    {
        var invoices = await _invoiceRepo.GetAllAsync();

        return invoices.Select(i => new InvoiceDto
        {
            InvoiceId = i.InvoiceId,
            ClientId = i.ClientId,
            TotalAmount = i.TotalAmount,
            Status = i.Status  
        }).ToList();
    }

    
    public async Task<InvoiceDto?> GetInvoiceByIdAsync(int id)
    {
        var invoice = await _invoiceRepo.GetByIdAsync(id);

        if (invoice == null)
            return null;

        return new InvoiceDto
        {
            InvoiceId = invoice.InvoiceId,
            ClientId = invoice.ClientId,
            TotalAmount = invoice.TotalAmount,
            Status = invoice.Status
        };
    }

    
    public async Task<bool> MarkInvoiceAsPaidAsync(int invoiceId)
    {
        var invoice = await _invoiceRepo.GetByIdAsync(invoiceId);

        if (invoice == null)
            return false;
        
        invoice.Status = InvoiceStatus.Paid;   
        await _invoiceRepo.UpdateAsync(invoice);

       
        var tasks = await _taskRepo.GetTasksByInvoiceIdAsync(invoiceId);

        foreach (var task in tasks)
        {
            task.Status = TaskStatus.Paid;   
        }

        await _taskRepo.UpdateRangeAsync(tasks);

        return true;
    }
}