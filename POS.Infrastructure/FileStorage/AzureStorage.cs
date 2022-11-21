using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace POS.Infrastructure.FileStorage
{
    public class AzureStorage : IAzureStorage
    {
        private readonly string _connectionString;
        public AzureStorage(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureStorage");
        }

        public async Task<string> SaveFile(string container, IFormFile file)
        {
            var client = new BlobContainerClient(_connectionString, container);

            await client.CreateIfNotExistsAsync();

            await client.SetAccessPolicyAsync(PublicAccessType.Blob);

            var extension = Path.GetExtension(file.FileName);

            var fileName = $"{Guid.NewGuid()}{extension}";

            var blob = client.GetBlobClient(fileName);

            await blob.UploadAsync(file.OpenReadStream());

            return blob.Uri.ToString();
        }

        public async Task<string> EditFile(string container, IFormFile file, string route)
        {
            await RemoveFile(route, container);
            return await SaveFile(container, file);
        }

        public async Task RemoveFile(string route, string container)
        {
            if (string.IsNullOrEmpty(route))
            {
                return;
            }

            var client = new BlobContainerClient(_connectionString, container);

            await client.CreateIfNotExistsAsync();

            var file = Path.GetFileName(route);
            var blob = client.GetBlobClient(file);

            await blob.DeleteIfExistsAsync();
        }
    }
}