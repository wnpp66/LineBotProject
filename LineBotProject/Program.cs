using LineBotProject.Chatbot;
using LineBotProject.Line;
using LineBotProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<CommandRouter>();
builder.Services.AddSingleton<MonkService>();
builder.Services.AddSingleton<TempleService>();
builder.Services.AddSingleton<LineClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
