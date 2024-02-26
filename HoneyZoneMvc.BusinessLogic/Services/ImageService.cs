using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class ImageService : IImageService
    {
        private ApplicationDbContext dbContext;

        public ImageService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> AddImageAsync(string name)
        {
           dbContext.ImageUrls.Add(new ImageUrl { Name = name });
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<ImageUrl> GetImageByIdAsync(int Id)
        {
           return await dbContext.ImageUrls.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<ImageUrl> GetImageByNameAsync(string fileName)
        {
            return await dbContext.ImageUrls.FirstOrDefaultAsync(x => x.Name == fileName);
        }
        public IEnumerable<ImageUrl> GetImages()
        {
            return dbContext.ImageUrls.ToList();
        }
    }
}
