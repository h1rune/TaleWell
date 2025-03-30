using Microsoft.AspNetCore.Http;

namespace ArtService.Application.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string path, CancellationToken cancellationToken);
        Task<string> UploadFileAsync(string text, string path, CancellationToken cancellationToken);

        string GeneratePreSignedUrl(string key, TimeSpan expiration);
        Task<string> ReadFileByKeyAsync(string key, CancellationToken cancellationToken);

        Task DeleteFileAsync(string key, CancellationToken cancellationToken);
    }
}
