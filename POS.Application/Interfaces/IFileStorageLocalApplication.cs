using Microsoft.AspNetCore.Http;

namespace POS.Application.Interfaces
{
    public interface IFileStorageLocalApplication
    {
        Task<string> SaveFile(string container, IFormFile file);
        Task<string> EditFile(string container, IFormFile file, string route);
        Task RemoveFile(string route, string container);
    }
}