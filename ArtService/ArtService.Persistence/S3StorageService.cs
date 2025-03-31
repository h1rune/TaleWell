using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ArtService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ArtService.Persistence
{
    public class S3StorageService : IStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3StorageService(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _bucketName = configuration["S3:BucketName"]!;
            _s3Client = s3Client;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string path, CancellationToken cancellationToken)
        {
            using var stream = file.OpenReadStream();
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = path,
                InputStream = stream,
                ContentType = file.ContentType
            };

            await _s3Client.PutObjectAsync(request, cancellationToken);
            return path;
        }

        public async Task<string> UploadFileAsync(string text, string path, CancellationToken cancellationToken)
        {
            var file = CreateFormFileFromText(text, path);
            return await UploadFileAsync(file, path, cancellationToken);
        }

        public IFormFile CreateFormFileFromText(string text, string fileName)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(text);
            var stream = new MemoryStream(byteArray);
            IFormFile formFile = new FormFile(stream, 0, stream.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };
            return formFile;
        }

        public string GeneratePreSignedUrl(string key, TimeSpan expiration)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key = key,
                Expires = DateTime.UtcNow.Add(expiration)
            };

            return _s3Client.GetPreSignedURL(request);
        }

        public async Task<string> ReadFileByKeyAsync(string key, CancellationToken cancellationToken)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            using var response = await _s3Client.GetObjectAsync(request, cancellationToken);
            using var reader = new StreamReader(response.ResponseStream);
            return await reader.ReadToEndAsync();
        }

        public async Task DeleteFileAsync(string key, CancellationToken cancellationToken)
        {
            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            await _s3Client.DeleteObjectAsync(deleteRequest, cancellationToken);
        }
    }

}
