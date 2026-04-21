using FreelancerFlow.API.Data;
using FreelancerFlow.API.Models;
using FreelancerFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreelancerFlow.API.Repositories.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> AddTask(TaskItem task)
        {
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<List<TaskItem>> GetAllTasks()
        {
            return await _context.TaskItems.Include(t => t.Client).ToListAsync();
        }

        public async Task<TaskItem?> GetTaskById(int id)
        {
            return await _context.TaskItems.Include(t => t.Client).FirstOrDefaultAsync(t => t.TaskId == id);
        }

        public async Task<List<TaskItem>> GetTasksByClientId(int clientId)
        {
            return await _context.TaskItems.Where(t => t.ClientId == clientId).ToListAsync();
        }
    }
}
