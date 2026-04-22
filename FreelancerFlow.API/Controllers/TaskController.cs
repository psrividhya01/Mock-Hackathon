using FreelancerFlow.API.DTOs.Task;
using FreelancerFlow.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var result = await _service.GetTasks();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Task data is null.");
            }
            var result = await _service.CreateTask(dto);
            return Ok(result);
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetTasksByClient(int clientId)
        {
            var result = await _service.GetTasksByClient(clientId);
            return Ok(result);
        }
    }
}
