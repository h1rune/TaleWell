using Amazon;
using Amazon.S3;
using ArtService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Database connection string is empty", nameof(connectionString));
            }

            services.AddDbContext<ArtServiceDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IArtServiceDbContext, ArtServiceDbContext>();

            services.AddSingleton<IAmazonS3>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var accessKey = configuration["S3:AccessKey"];
                var secretKey = configuration["S3:SecretKey"];
                var region = configuration["S3:Region"];
                return new AmazonS3Client(accessKey, secretKey, RegionEndpoint.GetBySystemName(region));
            });

            services.AddScoped<S3StorageService>();
            services.AddScoped<IStorageService, S3StorageService>();

            return services;
        }
    }
}
