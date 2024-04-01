using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string directoryPath);
    }
}
