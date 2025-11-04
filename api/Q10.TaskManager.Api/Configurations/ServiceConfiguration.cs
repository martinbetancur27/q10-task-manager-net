using Q10.TaskManager.Api.Workers;
using Q10.TaskManager.Infrastructure.Interfaces;
using Q10.TaskManager.Infrastructure.Repositories;
using Q10.TaskManager.Infrastructure.Services;

namespace Q10.TaskManager.Api.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<ICacheRepository, CacheRepository>();
            services.AddScoped<IConfig, SettingsRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            #endregion Repositories

            // RabbitMQ Services
            services.AddSingleton<IRabbitMQRepository, RabbitMQRepository>();
            services.AddHostedService<ProcessBulkWorker>();

            services.AddScoped<ITaskBulkQueryService, TaskBulkQueryService>();
            services.AddScoped<ITaskBulkCommandService, TaskBulkCommandService>(); 
            services.AddScoped<IProcessBulkService, ProcessBulkService>();

            #region Services

            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IAuthService, AuthService>();


            #endregion Services

            return services;
        }
    }
}