using Q10.TaskManager.Infrastructure.Entities;
using Q10.TaskManager.Infrastructure.Interfaces;
using Q10.TaskManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        public ITaskRepository TaskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }

        public Task<TaskItem> CreateTask(TaskItem taskItem)
        {
            if (taskItem == null)
            {
                throw new ArgumentNullException(nameof(taskItem));
            }

            var errors = new List<string>();

            if (string.IsNullOrEmpty(taskItem.Title))
                errors.Add("Task title cannot be null or empty");

            if (string.IsNullOrEmpty(taskItem.Description))
                errors.Add("Task description cannot be null or empty");

            if (taskItem.Created == default)
                errors.Add("Task created date is not valid");

            if (errors.Any())
                throw new ArgumentException(string.Join("; ", errors));

            var newTask = TaskRepository.CreateTaskAsync(taskItem);
            return newTask;
        }

        public Task<bool> DeleteTask(string id) => TaskRepository.DeleteTaskAsync(id);

        public async Task<IEnumerable<TaskItem>> GetAllTasks() => await TaskRepository.GetAllTasksAsync();

        public Task<TaskItem> GetTaskById(string id) => TaskRepository.GetTaskByIdAsync(id);

        public Task<TaskItem> UpdateTask(string id, TaskItem taskItem) => TaskRepository.UpdateTaskAsync(id, taskItem);
    }
}
