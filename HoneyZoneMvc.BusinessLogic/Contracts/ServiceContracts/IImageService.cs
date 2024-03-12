using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IImageService
    {
        IEnumerable<ImageUrl> GetImages();
        Task<bool> AddImageAsync(string name);
        Task<ImageUrl> GetImageByIdAsync(int Id);
        Task<ImageUrl> GetImageByNameAsync(string fileName);
    }
}
