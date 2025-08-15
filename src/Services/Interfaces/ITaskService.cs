using TaskManager.Api.Models;

namespace TaskManager.Api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> AddAsync(TaskItem task);
        Task<TaskItem?> MarkAsCompletedAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
