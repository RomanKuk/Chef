using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Chef.BLL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Chef.BLL.Providers
{
    public class FileProvider : IFileProvider
    {
        private readonly string _baseUrl = Environment.GetEnvironmentVariable(nameof(_baseUrl));
        public async Task<string> UploadUserPhoto(IFormFile file)
        {
            var folderName = Path.Combine("Resources", "Avatars");
            return await SaveFile(folderName, file);
        }

        private async Task<string> SaveFile(string relativePath, IFormFile file)
        {
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var filePath = Path.Combine(directoryPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return Path.Combine(_baseUrl, relativePath, fileName);
        }
    }
}
