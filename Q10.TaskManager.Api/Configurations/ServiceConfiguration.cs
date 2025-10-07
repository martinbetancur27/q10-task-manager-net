namespace Q10.TaskManager.Api.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<Infrastructure.Interfaces.ICacheRepository, Infrastructure.Repositories.CacheRepository>();
            services.AddScoped<Infrastructure.Interfaces.IConfig, Infrastructure.Repositories.SettingsRepository>();
            return services;
        }
    }
}
