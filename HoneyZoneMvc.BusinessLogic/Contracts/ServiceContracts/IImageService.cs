using HoneyZoneMvc.BusinessLogic.Contracts.SubContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IImageService:IReadable<ImageUrl>
    {
        Task<bool> AddAsync(string name);
        Task<ImageUrl> ByNameAsync(string fileName);
    }
}
