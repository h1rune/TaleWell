using AuthService.Application.Interfaces;
using AuthService.Domain;
using AuthService.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEmailService, EmailService>();
            services.AddIdentity<Account, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
            })
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

            services.AddScoped<ITokenCleanupService, TokenCleanupService>();
            services.AddHostedService<TokenCleanupService>();

            return services;
        }
    }
}
