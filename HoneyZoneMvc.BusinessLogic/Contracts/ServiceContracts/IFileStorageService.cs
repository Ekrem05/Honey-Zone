using Microsoft.AspNetCore.Http;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string directoryPath);
    }
}
