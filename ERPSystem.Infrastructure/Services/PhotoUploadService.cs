using ERPSystem.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Infrastructure.Services
{
    public class PhotoUploadService : IPhotoUploadService
    {
        private static readonly string[] PermittedExtensions =
            { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tif", ".tiff" };

        private readonly IWebHostEnvironment _webHostEnvironment;

        public PhotoUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private string UploadsFolder => Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatars");

        public async Task<string> SaveAsync(Stream content, string fileName)
        {
            if (content == null || fileName == null)
                return null;

            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !PermittedExtensions.Contains(ext))
                return null;

            var trustedFileNameForFileStorage = Path.GetRandomFileName();
            trustedFileNameForFileStorage = trustedFileNameForFileStorage.Substring(0, 8)
                + trustedFileNameForFileStorage.Substring(9) + ext;
            var filePath = Path.Combine(UploadsFolder, trustedFileNameForFileStorage);

            using (var fileStream = File.Create(filePath))
            {
                await content.CopyToAsync(fileStream);
            }

            return trustedFileNameForFileStorage;
        }

        public void DeleteIfProduction(string fileName)
        {
            if (!_webHostEnvironment.IsProduction() || string.IsNullOrEmpty(fileName))
                return;

            var fileToDelete = Path.Combine(UploadsFolder, fileName);
            if (File.Exists(fileToDelete))
                File.Delete(fileToDelete);
        }
    }
}
