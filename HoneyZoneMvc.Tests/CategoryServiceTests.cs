using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.Tests
{
    public class CategoryServiceTests
    {
        private ApplicationDbContext dbContext;
        private ICategoryService categoryService;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("HoneyZoneMvcTEST")
                .Options;

            dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureCreated();

            categoryService = new CategoryService(dbContext);
        }

        [Test]
        public async Task AddAsync_ShouldAddCategory()
        {

            var category = new CategoryAddViewModel()
            {
                Name = "Test"
            };
            await categoryService.AddAsync(category);
            var result = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);
            Assert.AreEqual(category.Name, result.Name);
        }
        [Test]
        public void AddAsync_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await categoryService.AddAsync(null));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await categoryService.AddAsync(new CategoryAddViewModel() { Name = "Honey" }));

        }
        [Test]
        public async Task ExistsAsync_ShouldReturnTrue()
        {
            var result = await categoryService.ExistsAsync("78355d47-6040-4676-9972-ac8be4f19882");
            Assert.IsTrue(result);
        }
        [Test]
        public async Task ExistsAsync_ShouldReturnFalse()
        {
            var result = await categoryService.ExistsAsync("78355d47-6040-4676-9972-ac8be4f19883");
            Assert.IsFalse(result);
        }
        [Test]
        public async Task DeleteAsync_ShouldDeleteCategory()
        {
            var category = new Category()
            {
                Id = Guid.Parse("57c9ad0a-e2de-4fe4-bd84-e017e06496bd"),
                Name = "Test"
            };
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            await categoryService.DeleteAsync("57c9ad0a-e2de-4fe4-bd84-e017e06496bd");
            var result = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);
            Assert.IsNull(result);
        }
        [Test]
        public void DeleteAsync_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await categoryService.DeleteAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await categoryService.DeleteAsync("57c9ad0a-e2de-4fe4-bd84-e017e06496bd"));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await categoryService.DeleteAsync("78355d47-6040-4676-9972-ac8be4f19882"));
        }
        [Test]
        public async Task AllAsync_ShouldReturnAllCategories()
        {
            var result = await categoryService.AllAsync();
            Assert.AreEqual(4, result.Count());
        }
        [Test]
        public async Task GetByIdAsync_ShouldReturnCategory()
        {
            var result = await categoryService.GetByIdAsync("78355d47-6040-4676-9972-ac8be4f19882");
            Assert.AreEqual("Honey", result.Name);
        }

        [TearDown]
        public void Cleanup()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }

    }
}
