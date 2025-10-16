using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Q10.TaskManager.Api.Configurations
{
    public static class SwaggerConfigurations
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Q10 Task Manager API",
                    Version = "v1",
                    Description = "API para gestión de tareas del curso Q10. Permite crear, leer, actualizar y eliminar tareas de manera eficiente.",
                    Contact = new OpenApiContact
                    {
                        Name = "Q10 Development Team",
                        Email = "dev@q10.com"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Q10 Task Manager API v1");
                c.RoutePrefix = "swagger";
            });

            return app;
        }
    }
}