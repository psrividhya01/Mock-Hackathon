using FreelancerFlow.API.DTOs.Task;
using FreelancerFlow.API.Enums;
using FreelancerFlow.API.Models;
using FreelancerFlow.API.Repositories.Interfaces;
using FreelancerFlow.API.Services.Interfaces;

namespace FreelancerFlow.API.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskResponseDto> CreateTask(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                ClientId = dto.ClientId,
                HoursWorked = dto.HoursWorked,
                Description = dto.Description,
                Status = TaskItemStatus.UnBilled
            };

            var result = await _repository.AddTask(task);

            return new TaskResponseDto
            {
                TaskId = result.TaskId,
                ClientId = result.ClientId,
                HoursWorked = result.HoursWorked,
                Description = result.Description,
                Status = result.Status.ToString()
            };
        }

        public async Task<List<TaskResponseDto>> GetTasks()
        {
            var tasks = await _repository.GetAllTasks();

            return tasks.Select(t => new TaskResponseDto
            {
                TaskId = t.TaskId,
                ClientId = t.ClientId,
                HoursWorked = t.HoursWorked,
                Description = t.Description,
                Status = t.Status.ToString()
            }).ToList();
        }

        public async Task<List<TaskResponseDto>> GetTasksByClient(int clientId)
        {
            var tasks = await _repository.GetTasksByClientId(clientId);

            return tasks.Select(t => new TaskResponseDto
            {
                TaskId = t.TaskId,
                ClientId = t.ClientId,
                HoursWorked = t.HoursWorked,
                Description = t.Description,
                Status = t.Status.ToString()
            }).ToList();
        }
    }
}
