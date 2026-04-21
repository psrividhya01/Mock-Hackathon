using FreelancerFlow.API.DTOs.Task;

namespace FreelancerFlow.API.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResponseDto> CreateTask(CreateTaskDto dto);
        Task<List<TaskResponseDto>> GetTasks();
        Task<List<TaskResponseDto>> GetTasksByClient(int clientId);
    }
}
