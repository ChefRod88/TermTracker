using TermTracker.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSignalR(); // ✅ SignalR service
builder.Services.AddOpenApi(); // Optional: OpenAPI UI

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Swagger UI
}

app.UseHttpsRedirection();

// ✅ Map the SignalR Hub before app.Run
app.MapHub<ChatHub>("/chathub");

// Optional: Sample API (you can delete this later)
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

// ✅ Run the app (last line!)
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
