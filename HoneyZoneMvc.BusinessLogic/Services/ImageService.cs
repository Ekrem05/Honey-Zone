﻿using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class ImageService : IImageService
    {
        private ApplicationDbContext dbContext;

        public ImageService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> AddAsync(string name)
        {
            dbContext.ImageUrls.Add(new ImageUrl { Name = name });
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<ImageUrl> ImageByIdAsync(int Id)
        {
            return await dbContext.ImageUrls.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<ImageUrl> ImageByNameAsync(string fileName)
        {
            return await dbContext.ImageUrls.FirstOrDefaultAsync(x => x.Name == fileName);
        }
        public IEnumerable<ImageUrl> All()
        {
            return dbContext.ImageUrls.ToList();
        }
    }
}
