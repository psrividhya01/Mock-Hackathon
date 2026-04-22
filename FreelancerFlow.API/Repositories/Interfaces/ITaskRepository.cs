using FreelancerFlow.API.Models;

namespace FreelancerFlow.API.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem> AddTask(TaskItem task);
        Task<List<TaskItem>> GetAllTasks();
        Task<TaskItem?> GetTaskById(int id);
        Task<List<TaskItem>> GetTasksByClientId(int clientId);
    }
}
