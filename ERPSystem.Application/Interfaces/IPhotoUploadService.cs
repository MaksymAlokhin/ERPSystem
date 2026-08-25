using System.IO;
using System.Threading.Tasks;

namespace ERPSystem.Application.Interfaces
{
    // Stores/removes employee profile photos under wwwroot/images/avatars.
    public interface IPhotoUploadService
    {
        // Saves the uploaded content under a random, trusted file name and returns
        // that file name, or null if there was no content or its extension isn't allowed.
        Task<string> SaveAsync(Stream content, string fileName);

        // Seeded demo avatars are shared in non-Production environments, so old
        // photos are only deleted from disk once the app is actually in Production.
        void DeleteIfProduction(string fileName);
    }
}
