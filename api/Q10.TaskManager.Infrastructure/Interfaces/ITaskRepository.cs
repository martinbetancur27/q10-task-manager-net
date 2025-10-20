using Q10.TaskManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infrastructure.Interfaces
{
    public interface ITaskRepository
    {
        Task<IQueryable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(string id);
        Task<TaskItem> CreateTaskAsync(TaskItem task);
        Task<TaskItem> UpdateTaskAsync(string id, TaskItem task);
        Task<bool> DeleteTaskAsync(string id);
    }
}
