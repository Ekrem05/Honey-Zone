using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Tests
{
    internal class DeliveryServiceTests
    {
        private IDeliveryService deliveryService;
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

            deliveryService = new DeliveryService(dbContext);
        }

        [Test]
        public async Task AllAsync_ReturnsCorrectData()
        {
            var result = await deliveryService.AllAsync();

            Assert.That(result.Count(), Is.EqualTo(2), "AllAsync() does not return all statuses");
            Assert.That(result.ElementAt(0).Name, Is.EqualTo("Speedy"), "AllAsync() does not return \"Speedy\" delivery");
            Assert.That(result.ElementAt(1).Name, Is.EqualTo("Econt"), "AllAsync() does not return \"Econt\" delivery");

        }

        [Test]
        public async Task GetByIdAsync_ReturnsCorrectData()
        {
            dbContext.DeliverMethods.Add(new DeliveryMethod() { Id = Guid.Parse("7a8a3c3a-0f67-4741-8fc4-ec3d427f3933"), Name = "Test" });
            dbContext.SaveChanges();

            var model = await deliveryService.GetByIdAsync("7a8a3c3a-0f67-4741-8fc4-ec3d427f3933");
            Assert.That(model.Name, Is.EqualTo("Test"), "GetByIdAsync() does not return correct delivery");
        }

        [Test]
        public void GetByIdAsync_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()=>await deliveryService.GetByIdAsync(null)
            , "GetByIdAsync() does not throw ArgumentNullException");

            Assert.ThrowsAsync<InvalidOperationException>(async () => await deliveryService.GetByIdAsync("080ecb9c-d669-4597-b7c3-c8e35e5abbd8"));
        }

        [TearDown]
        public void CleanUp()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
