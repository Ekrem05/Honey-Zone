using HoneyZoneMvc.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IImageService
    {
        IEnumerable<ImageUrl> GetImages();
        Task<bool>AddImageAsync(string name);
        Task<ImageUrl> GetImageByIdAsync(int Id);
        Task<ImageUrl> GetImageByNameAsync(string fileName);
    }
}
