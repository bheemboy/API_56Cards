using API_56Cards.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors(builder => builder
    .WithOrigins("null")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.MapHub<Cards56Hub>("/API_56Cards");

app.Run();
