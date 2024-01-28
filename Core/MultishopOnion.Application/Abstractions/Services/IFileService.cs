using Microsoft.AspNetCore.Http;
using MultishopOnion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Abstractions.Services
{
    public interface IFileService
    {
        void CheckFileType(IFormFile file, FileType type);
        void CheckFileSize(IFormFile file, int maxSize);
        Task<string> CreateFileAsync(IFormFile file, string rootPath, params string[] folders);
        void DeleteFile(string fileName, string rootPath, params string[] folders);
    }
}
