using ChannelService.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.Run();
