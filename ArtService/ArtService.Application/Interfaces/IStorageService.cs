using Microsoft.AspNetCore.Http;

namespace ArtService.Application.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string path);
    }
}
