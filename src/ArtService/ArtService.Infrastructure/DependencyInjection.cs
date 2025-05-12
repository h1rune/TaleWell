using ArtService.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArtService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IArchetypeService, ArchetypeService>();
            return services;
        }
    }
}
