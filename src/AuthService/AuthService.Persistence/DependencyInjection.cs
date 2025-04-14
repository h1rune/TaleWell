using AuthService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DB:Connection"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Database connection string is empty", nameof(connectionString));
            }

            services.AddDbContext<AuthServiceDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IAuthServiceDbContext, AuthServiceDbContext>();

            return services;
        }
    }
}
