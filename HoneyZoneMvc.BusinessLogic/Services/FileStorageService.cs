using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class FileStorageService : IFileStorageService
    {
        public async Task<string> SaveFileAsync(IFormFile file, string directoryPath)
        {
            string filePath = Path.Combine(directoryPath, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return file.FileName;
        }
    }
}
