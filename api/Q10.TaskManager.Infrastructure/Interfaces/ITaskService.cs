using Q10.TaskManager.Infrastructure.Entities;
namespace Q10.TaskManager.Infrastructure.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();
        Task<TaskItem> GetTaskById(string id);
        Task<TaskItem> CreateTask(TaskItem taskItem);
        Task<TaskItem> UpdateTask(string id, TaskItem taskItem);
        Task<bool> DeleteTask(string id);
    }
}
