using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IImageService
    {
        IEnumerable<ImageUrl> All();
        Task<bool> AddAsync(string name);
        Task<ImageUrl> ImageByIdAsync(int Id);
        Task<ImageUrl> ImageByNameAsync(string fileName);
    }
}
