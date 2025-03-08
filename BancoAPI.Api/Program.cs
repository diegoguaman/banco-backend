var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Add support for controllers
builder.Services.AddControllers();

// ✅ 2. Habilitar Swagger (para documentación de API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Crear la aplicación
var app = builder.Build();

// ✅ 3. Configurar el pipeline de la aplicación

// 🔹 Habilitar Swagger en desarrollo y producción
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 En producción, es recomendable activar HTTPS
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection(); // Habilita redirección a HTTPS en producción
}

// ✅ 4. Habilitar rutas de controladores
app.UseAuthorization();
app.MapControllers();

// 🔹 Endpoint de prueba "weatherforecast"
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

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
.WithName("GetWeatherForecast");

app.Run();


// ✅ 5. Definir el modelo para el endpoint "weatherforecast"
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
