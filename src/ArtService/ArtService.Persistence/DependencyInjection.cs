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
            var connectionString = configuration["DB:Connection"];
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
                var s3Config = new AmazonS3Config
                {
                    ServiceURL = configuration["S3:ServiceUrl"],
                    ForcePathStyle = true
                };
                return new AmazonS3Client(accessKey, secretKey, s3Config);
            });

            services.AddScoped<S3StorageService>();
            services.AddScoped<IStorageService, S3StorageService>();

            return services;
        }
    }
}
