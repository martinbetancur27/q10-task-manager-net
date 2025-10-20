using Microsoft.EntityFrameworkCore;
using Q10.TaskManager.Infrastructure.Data;
using Q10.TaskManager.Infrastructure.Entities;
using Q10.TaskManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public PostgreSQLContext Context { get; set; }

        public TaskRepository(PostgreSQLContext context) 
        { 
            Context = context;
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem taskItem)
        {
            await Context.TaskItems.AddAsync(taskItem);
            await Context.SaveChangesAsync();

            return taskItem;
        }

        public async Task<bool> DeleteTaskAsync(string id)
        {
            var task = await GetTaskByIdAsync(id);
            if (task == null) return false;

            Context.TaskItems.Remove(task);
            await Context.SaveChangesAsync();

            return true;
        }

        public Task<IQueryable<TaskItem>> GetAllTasksAsync()
        {
            var tasks = Context.TaskItems.AsQueryable();
            return Task.FromResult(tasks);
        }

        public async Task<TaskItem> GetTaskByIdAsync(string id) => await Context.TaskItems.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<TaskItem> UpdateTaskAsync(string id, TaskItem taskItem)
        {
            taskItem.Id = id;
            Context.Entry(taskItem).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return taskItem;
        }
    }
}
