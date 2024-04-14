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
    internal class StatusServiceTests
    {
        private IStatusService statusService;
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

            statusService = new StatusService(dbContext);
        }

        [Test]
        public async Task AllAsync_ReturnsCorrectData()
        {
            var result = await statusService.AllAsync();

            Assert.That(result.Count(), Is.EqualTo(5), "AllAsync() does not return all statuses");
            Assert.That(result.ElementAt(0).Name, Is.EqualTo("Confirmed"), "AllAsync() does not return \"Confirmed\" status");
            Assert.That(result.ElementAt(1).Name, Is.EqualTo("Pending"), "AllAsync() does not return \"Pending\" status");
            Assert.That(result.ElementAt(2).Name, Is.EqualTo("Sent"), "AllAsync() does not return \"Sent\" status");
            Assert.That(result.ElementAt(3).Name, Is.EqualTo("Delivered"), "AllAsync() does not return \"Delivered\" status");
            Assert.That(result.ElementAt(4).Name, Is.EqualTo("Cancelled"), "AllAsync() does not return \"Cancelled\" status");
        }

        [Test]
        public async Task GetByIdAsync_ReturnsCorrectData()
        {
            dbContext.Statuses.Add(new Status() { Id = Guid.Parse("7a8a3c3a-0f67-4741-8fc4-ec3d427f3933"), Name = "Test" });
            dbContext.SaveChanges();

            var model = await statusService.GetByIdAsync("7a8a3c3a-0f67-4741-8fc4-ec3d427f3933");
            Assert.That(model.Name, Is.EqualTo("Test"), "GetByIdAsync() does not return correct status");
        }

        [Test]
        public void GetByIdAsync_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()=>await statusService.GetByIdAsync(null)
            , "GetByIdAsync() does not throw ArgumentNullException");

            Assert.ThrowsAsync<InvalidOperationException>(async () => await statusService.GetByIdAsync("080ecb9c-d669-4597-b7c3-c8e35e5abbd8"));
        }

        [TearDown]
        public void CleanUp()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
