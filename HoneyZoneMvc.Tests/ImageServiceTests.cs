using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Tests
{
    internal class ImageServiceTests
    {
        private IImageService imageService;
        private DbContextOptions<ApplicationDbContext> dbOptions;
        private ApplicationDbContext dbContext;

        [OneTimeSetUp]
        public void Setup()
        {
            dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("HoneyZoneMvc" + Guid.NewGuid().ToString())
                .Options;
            dbContext = new ApplicationDbContext(dbOptions);
            dbContext.Database.EnsureCreated();

            imageService = new ImageService(dbContext);
        }


        [Test]
        public async Task AddAsync_ShouldAddImage()
        {
            await imageService.AddAsync("image1.jpg");
            var image = await dbContext.ImageUrls.FirstOrDefaultAsync();
            Assert.AreEqual("image1.jpg", image.Name);
        }
        [Test]
        public async Task GetByIdAsync_ShouldReturnImage()
        {
            var image = new ImageUrl() { Name = "image1.jpg" };
            await dbContext.ImageUrls.AddAsync(image);
            await dbContext.SaveChangesAsync();
            var result = await imageService.GetByIdAsync(image.Id.ToString());
            Assert.AreEqual("image1.jpg", result.Name);
        }
        [Test]
        public async Task ImageByNameAsync_ShouldReturnImage()
        {
            var image = new ImageUrl() { Name = "image1.jpg" };
            await dbContext.ImageUrls.AddAsync(image);
            await dbContext.SaveChangesAsync();
            var result = await imageService.ByNameAsync("image1.jpg");
            Assert.AreEqual("image1.jpg", result.Name);
        }
        [Test]
        public async Task AllAsync_ShouldReturnAllImages()
        {
            var image1 = new ImageUrl() { Name = "image1.jpg" };
            var image2 = new ImageUrl() { Name = "image2.jpg" };
            await dbContext.ImageUrls.AddRangeAsync(image1, image2);
            await dbContext.SaveChangesAsync();
            var result = await imageService.AllAsync();
            Assert.AreEqual(2, result.Count());
        }

        [TearDown]
        public void CleanUp()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
