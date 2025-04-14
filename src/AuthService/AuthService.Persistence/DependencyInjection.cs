using AuthService.Application.Interfaces;
using AuthService.Domain;
using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<Account, IdentityRole>()
                .AddEntityFrameworkStores<AuthServiceDbContext>()
                .AddDefaultTokenProviders();

            services.AddOpenIddict()
                .AddCore(opt => opt.UseEntityFrameworkCore().UseDbContext<AuthServiceDbContext>())
                .AddServer(opt =>
                {
                    opt.AllowPasswordFlow();
                    opt.AllowRefreshTokenFlow();
                    opt.SetTokenEndpointUris("/connect/token");

                    opt.AddEphemeralEncryptionKey()
                        .AddEphemeralSigningKey()
                        .UseAspNetCore()
                        .EnableTokenEndpointPassthrough();
                });

            return services;
        }
    }
}
