using FreelancerFlow.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var result = await _service.GetInvoices();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var result = await _service.GetInvoiceById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("generate/{clientId}")]
        public async Task<IActionResult> GenerateInvoice(int clientId)
        {
            try
            {
                var result = await _service.GenerateInvoice(clientId);
                return CreatedAtAction(nameof(GetInvoiceById), new { id = result.InvoiceId }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/pay")]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            await _service.MarkAsPaid(id);
            return NoContent();
        }
    }
}
