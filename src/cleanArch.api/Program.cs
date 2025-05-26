using cleanArch.Application.Interfaces;
using cleanArch.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

// create path /ping 
app.MapGet("/ping", () => "pong")
    .WithName("Ping")
    .WithSummary("Returns pong for ping requests");

// gen swagger docs
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
// set auto redirect to swagger
app.MapGet("/", () => Results.Redirect("/swagger/index.html"))
    .ExcludeFromDescription(); // Exclude from Swagger documentation
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
