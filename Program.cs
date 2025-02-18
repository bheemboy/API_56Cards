using API_56Cards.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks()
    .AddCheck<SignalRHealthCheck>("signalr_health_check");
builder.Services.AddCors();
builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors(builder => builder
    .WithOrigins("null")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.MapGet("/", () => $"API_56Cards: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

app.MapHealthChecks("/health");
app.MapHub<Cards56Hub>("/API_56Cards");

app.Run();
