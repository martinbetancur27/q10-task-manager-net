using Q10.TaskManager.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

/// <summary>
/// Obtiene el pronóstico del tiempo para los próximos 5 días
/// </summary>
/// <returns>Lista de pronósticos del tiempo</returns>
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithTags("Weather");

app.Run();

/// <summary>
/// Representa un pronóstico del tiempo
/// </summary>
/// <param name="Date">Fecha del pronóstico</param>
/// <param name="TemperatureC">Temperatura en Celsius</param>
/// <param name="Summary">Resumen del clima</param>
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    /// <summary>
    /// Temperatura en Fahrenheit
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
