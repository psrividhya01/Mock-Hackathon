using FreeLancerProj.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeLancerProj.Controller;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    
//1
    [HttpPost ("generate/{clientId}")]
    public async Task<IActionResult> GenerateInvoice(int clientId)
    {
        var result = await _invoiceService.GenerateInvoiceAsync(clientId);
        if (result == null)
        {
            return BadRequest("No unbilled  tasks is found  for this  client ");
        }

        return Ok(result);
    }
//2
    [HttpGet("{invoiceId}")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);

        if (invoice == null)
            return NotFound("Invoice not found.");

        return Ok(invoice);
    }
    //3
    [HttpGet]
    public async Task<IActionResult> GetAllInvoices()
    {
        var invoices = await _invoiceService.GetAllInvoicesAsync();
        return Ok(invoices);
    }

  //4  
    [HttpPut("mark-paid/{invoiceId}")]
    public async Task<IActionResult> MarkInvoiceAsPaid(int invoiceId)
    {
        var success = await _invoiceService.MarkInvoiceAsPaidAsync(invoiceId);
        
        if (!success)
            return NotFound("Invoice not found.");

        return Ok("Invoice marked as paid successfully.");
    }
    
}
        
    
