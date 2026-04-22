using FreelancerFlow.API.Models;
using FreelancerFlow.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FreelancerFlow.API.DTOs.Client;

namespace FreelancerFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Client data is null.");
            }
            var result = await _service.CreateClient(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _service.GetClients();
            return Ok(result);
        }
    }
}
