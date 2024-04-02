using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;
using HoneyZoneMvc.Data;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HoneyZoneMvc.Tests
{
    public class StatisticServiceTests
    {
        private ICategoryService categoryService;
        private IStatisticService statisticService;

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

            var products = new List<ProductAdminViewModel>
            {
                new ProductAdminViewModel { Id = Guid.NewGuid().ToString(), Name = "Product1", QuantityInStock = 10},
                new ProductAdminViewModel { Id = Guid.NewGuid().ToString(), Name = "Product2", QuantityInStock = 20 },
                new ProductAdminViewModel { Id = Guid.NewGuid().ToString(), Name = "Product3", QuantityInStock = 30}
            };
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(x => x.AllAsync()).ReturnsAsync(products);


            categoryService = new Mock<ICategoryService>().Object;
            statisticService = new StatisticService(productServiceMock.Object, categoryService, dbContext);
        }


        [Test]
        public async Task StockStatisticsAsync_ReturnsCorrectData()
        {
            var result = await statisticService.StockStatisticsAsync();

            Assert.That(result.ProductsInStockPair.Count, Is.EqualTo(3));
            Assert.That(result.ProductsInStockPair["Product1"], Is.EqualTo(10));
            Assert.That(result.ProductsInStockPair["Product2"], Is.EqualTo(20));
            Assert.That(result.ProductsInStockPair["Product3"], Is.EqualTo(30));
        }

        [TearDown]
        public void CleanUp()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
