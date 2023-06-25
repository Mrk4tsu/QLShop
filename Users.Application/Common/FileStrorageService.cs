using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Common
{
    public class FileStrorageService : IStorageService
    {
        private readonly string _useContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public FileStrorageService(IWebHostEnvironment webHostEnvironment)
        {
            _useContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);
        }
        public async Task DeleteFileAsync(string filename)
        {
            var filePath = Path.Combine(_useContentFolder, filename);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string filename)
        {
            return $"{USER_CONTENT_FOLDER_NAME}/{filename}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string filename)
        {
            var filePath = Path.Combine(_useContentFolder, filename);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }
    }
}
