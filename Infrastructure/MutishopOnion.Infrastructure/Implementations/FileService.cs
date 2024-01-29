using Microsoft.AspNetCore.Http;
using MultishopOnion.Application.Abstractions.Services;
using MultishopOnion.Application.Exceptions;
using MultishopOnion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutishopOnion.Infrastructure.Implementations
{
    internal class FileService : IFileService
    {
        public void CheckFileSize(IFormFile file, int maxSize)
        {
            if (file.Length >= maxSize * 1024) throw new FileValidationException($"File size must be less than {maxSize}KB!");
        }

        public void CheckFileType(IFormFile file, FileType type)
        {
            switch (type)
            {
                case FileType.Image:
                    if (!file.ContentType.Contains("image/")) throw new FileValidationException("Invalid upload! Expected image!");
                    break;
                case FileType.Audio:
                    if (!file.ContentType.Contains("audio/")) throw new FileValidationException("Invalid upload! Expected audio!");
                    break;
                case FileType.Video:
                    if (!file.ContentType.Contains("video/")) throw new FileValidationException("Invalid upload! Expected video!");
                    break;

            }
        }

        public async Task<string> CreateFileAsync(IFormFile file, string rootPath, params string[] folders)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName.Substring(file.FileName.LastIndexOf("."));
            string path = _generatePath(fileName, rootPath, folders);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;

        }

        public void DeleteFile(string fileName, string rootPath, params string[] folders)
        {
            string path = _generatePath(fileName, rootPath, folders);
            if (File.Exists(path)) File.Delete(path);
        }

        private string _generatePath(string fileName, string rootPath, params string[] folders)
        {
            string path = rootPath;
            foreach (var folder in folders)
            {
                path = Path.Combine(path, folder);
            }
            return Path.Combine(path, fileName);
        }
    }
}
