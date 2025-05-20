using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TermTracker.API;
using TermTracker.API.Data;


var builder = WebApplication.CreateBuilder(args);

// ✅ Add services
builder.Services.AddControllers(); // Required to use API controllers

// ✅ Add SignalR for real-time communication
builder.Services.AddSignalR();

// ✅ Add EF Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Add Swagger/OpenAPI (fixes your current issue)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Term Tracker API",
        Version = "v1",
        Description = "API for student forum, chat, and study sessions"
    });
});

var app = builder.Build();

// ✅ Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Term Tracker API v1");
    });
}

// ✅ Middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// ✅ Map API controllers and SignalR Hub
app.MapControllers();                 // <-- Enables ForumController and ChatController
app.MapHub<ChatHub>("/chathub");      // <-- Enables real-time chat

// ✅ Optional root path
app.MapGet("/", () => "✅ Term Tracker API is running. Visit /swagger for docs.");

// ✅ Sample weather API (safe to remove)
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
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

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
