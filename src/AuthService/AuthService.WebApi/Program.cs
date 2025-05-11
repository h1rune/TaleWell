using AuthService.Application.Common.Mappings;
using AuthService.Application.Interfaces;
using AuthService.Application;
using System.Reflection;
using AuthService.Persistence;
using AuthService.Infrastructure;
using Microsoft.OpenApi.Models;
using AuthService.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IAuthServiceDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var domain = builder.Configuration["Domain"]!;
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow", policy =>
    {
        policy.WithOrigins(domain, $"api.{domain}");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.AddServer(new OpenApiServer
    {
        Url = "/auth"
    });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Auth Service API",
        Version = "v1"
    });
    options.AddSecurityDefinition("cookieAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Cookie,
        Name = "access_token",
        Description = "Access token из cookie"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "cookieAuth"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AuthServiceDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "An error occurred while app initialization");
    }
}

app.UseSwagger();            
app.UseSwaggerUI();
app.UseCustomExceptionHandler();
app.UseRouting();
app.UseCors("Allow");
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
