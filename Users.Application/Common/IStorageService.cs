using System.IO;
using System.Threading.Tasks;

namespace Users.Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string filename);
        Task SaveFileAsync(Stream mediaBinaryStream, string filename);
        Task DeleteFileAsync(string filename);
    }
}
