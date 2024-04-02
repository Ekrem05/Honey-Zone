using AutoMapper;
using HoneyZoneMvc.BusinessLogic.AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Enums;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HoneyZoneMvc.Tests
{
    /// <summary>
    /// This class contains tests for the ProductService class.
    /// </summary>
    public class ProductServiceTests
    {
        private DbContextOptions<ApplicationDbContext> dbOptions;
        private ApplicationDbContext dbContext;

        private IProductService productService;
        private ICategoryService categoryService;
        private IImageService imageService;
        private IFileStorageService fileStorageService;
        private IMapper mapper;

        private IFormFile fileMock;

        [OneTimeSetUp]
        public void Setup()
        {
            dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase("HoneyZoneMvc" + Guid.NewGuid().ToString())
                  .Options;
            dbContext = new ApplicationDbContext(dbOptions);
            dbContext.Database.EnsureCreated();

            categoryService = new Mock<ICategoryService>().Object;
            var imageServiceMock = new Mock<IImageService>();
            imageServiceMock.Setup(s => s.All()).Returns(new List<ImageUrl>());
            imageService = imageServiceMock.Object;

            mapper = new MapperConfiguration(mc => mc.AddProfile(new MyProfile())).CreateMapper();

            var fileMockRes = new Mock<IFormFile>();
            fileMockRes.Setup(f => f.FileName).Returns("test.jpg");
            fileMock = fileMockRes.Object;

            var fileStorageServiceMock = new Mock<IFileStorageService>();
            fileStorageServiceMock.Setup(f => f.SaveFileAsync(It.IsAny<IFormFile>(), It.IsAny<string>()))
                                  .ReturnsAsync("test.jpg");
            fileStorageService = fileStorageServiceMock.Object;

            productService = new ProductService(dbContext, categoryService, imageService, mapper, fileStorageService);
        }

        [Test]
        public async Task AddProductAsync_Successfully_Test()
        {

            var imageMockOne = new Mock<IFormFile>();
            imageMockOne.Setup(f => f.FileName).Returns("image1.jpg");
            var imageMockTwo = new Mock<IFormFile>();
            imageMockTwo.Setup(f => f.FileName).Returns("image2.jpg");
            productService.AddAsync(new ProductAddViewModel
            {
                Name = "Test Product",
                CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882").ToString(),
                Price = 29.99,
                Description = "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.",
                QuantityInStock = 27,
                ProductAmount = "1kg",
                MainImage = fileMock,
                Images = new List<IFormFile>() { imageMockOne.Object, imageMockTwo.Object }
            }).Wait();

            Assert.That(dbContext.Products.FirstOrDefault(p => p.Name == "Test Product").Images.Any(i => i.Name == "image1.jpg"), "Adding product does not save the image");
            Assert.That(dbContext.Products.FirstOrDefault(p => p.Name == "Test Product").Images.Count() == 3, "Adding product does not save the image");

            Assert.That((dbContext.Products.FirstOrDefault(p => p.Name == "Test Product")?.MainImageUrl == "test.jpg"), "Adding product does not save the image");
            Assert.That(dbContext.Products.Any(p => p.Name == "Test Product"), "Adding product does not work");
            Assert.That(dbContext.Products.Count() == 8, "Adding product does not work");

        }
        [Test]
        public void AddProductAsync_ThrowsException_WhenNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.AddAsync(null));
        }
        [Test]
        public async Task AllAsync_ReturnsAllProducts()
        {
            var products = await productService.AllAsync();
            Assert.That(products.Count() == 7, "AllAsync does not return all products");
        }
        [Test]
        public async Task AllAsyncSorting_WorksCorrectly()
        {
            var vm = await productService.AllAsync("Honey", "a", ProductSorting.Price, 1, 3);
            Assert.That(vm.Products.ElementAt(0).Name == "Manuka Honey" && vm.Products.ElementAt(1).Name == "Acacia honey", "AllAsync does not sort correctly");
            vm = await productService.AllAsync("Honey", "a", ProductSorting.Name, 1, 3);
            Assert.That(vm.Products.ElementAt(0).Name == "Acacia honey" && vm.Products.ElementAt(1).Name == "Manuka Honey", "AllAsync does not return all products");
            vm = await productService.AllAsync("Honey", "a", ProductSorting.TimesOrdered, 1, 3);
            Assert.That(vm.Products.ElementAt(0).Name == "Manuka Honey" && vm.Products.ElementAt(1).Name == "Acacia honey", "AllAsync does not return all products");
            vm = await productService.AllAsync("Honey", "a", 0, 1, 3);
            Assert.That(vm.Products.ElementAt(0).Name == "Acacia honey" && vm.Products.ElementAt(1).Name == "Manuka Honey", "AllAsync does not return all products");

        }
        [Test]
        public async Task GetByCategoryNameAsync_WorksCorrectly()
        {
            var products = await productService.GetByCategoryNameAsync("All");
            Assert.That(products.Count() == 7, "GetByCategoryNameAsync does not return all products");
            products = await productService.GetByCategoryNameAsync("Honey");
            Assert.That(products.Count() == 3, "GetByCategoryNameAsync does not return products with sepcified category");
            products = await productService.GetByCategoryNameAsync("Bee Pollen");
            Assert.That(products.Count() == 1, "GetByCategoryNameAsyncdoes not return products with sepcified category");
        }
        [Test]
        public void GetByCategoryNameAsync_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.GetByCategoryNameAsync(null));
        }
        [Test]
        public async Task GetByCategoryId_WorksCorrectly()
        {
            var products = await productService.GetByCategoryIdAsync("78355d47-6040-4676-9972-ac8be4f19882");
            Assert.That(products.Count() == 3, "GetGetByCategoryId does not return a correct value");
            products = await productService.GetByCategoryIdAsync("eb2aecdd-7815-49aa-973b-ee3173760fc5");
            Assert.That(products.Count() == 2, "GetGetByCategoryId does not return a correct value");
        }
        [Test]
        public async Task GetById_WorksCorrectly()
        {
            var product = await productService.GetByIdAsync("c7ecd019-40b1-47f3-89c4-67e3625f796b");
            Assert.That(product.Name == "Sunflower Honey", "GetById does not return a correct value");

        }
        [Test]
        public void GetById_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.GetByIdAsync(null));
        }
        [Test]
        public async Task GetBestSellersAsync_WorksCorrectly()
        {
            var products = await productService.GetBestSellersAsync();
            Assert.That(products.First().Name == "Manuka Honey" && products.ElementAt(1).Name == "Acacia honey", "GetBestSellersAsync does not return a correct value");
        }
        [Test]
        public async Task UpdateAsync_WorksCorrectly()
        {
            var products = dbContext.Products.ToList();
            ProductEditViewModel vm = new ProductEditViewModel
            {
                Id = Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                Name = "Test Product",
                CategoryId = "78355d47-6040-4676-9972-ac8be4f19882",
                Price = 1.99,
                Description = "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.",
                QuantityInStock = 27,
                ProductAmount = "1kg",
            };
            var product = await productService.GetByIdAsync("c7ecd019-40b1-47f3-89c4-67e3625f796b");
            await productService.UpdateAsync(vm);
            Assert.That(dbContext.Products.FirstOrDefault(p => p.Name == "Test Product").Price == 1.99, "UpdateAsync does not work");
        }
        [Test]
        public async Task DeleteAsync_WorksCorrectly()
        {
            var products = dbContext.Products.ToList();
            await productService.DeleteAsync("c7ecd019-40b1-47f3-89c4-67e3625f796b");
            Assert.That(!dbContext.Products.Any(p => p.Id == Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b")), "DeleteAsync does not work");

        }
        [Test]
        public async Task DeleteAsync_DoesntDeleteProductsInActiveOrders()
        {
            var productIdForDelete = dbContext.Products.FirstOrDefault(p => p.Name == "Wildflower Pollen").Id;
            dbContext.Orders.Add(new Order()
            {
                ClientId = Guid.Parse("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                StatusId = dbContext.Statuses.FirstOrDefault(s => s.Name == "Confirmed").Id,
                TotalSum = 100,
                OrderDate = DateTime.Now,
                DeliveryMethodId = dbContext.DeliverMethods.FirstOrDefault(s => s.Name == "Econt").Id,
                OrderDetailId = new OrderDetail()
                {
                    Address = "Test",
                    City = "Test",
                    Email = "Test",
                    FirstName = "Test",
                    LastName = "Test",
                    PhoneNumber = "Test",
                    ZipCode = "Test"
                }.Id,
                OrderProducts = new List<OrderProduct>()
                {
                    new OrderProduct()
                    {
                        ProductId = productIdForDelete,
                        Quantity = 1
                    }
                }

            });
            await dbContext.SaveChangesAsync();
            Assert.ThrowsAsync<InvalidOperationException>(async () => await productService.DeleteAsync(productIdForDelete.ToString()));
        }
        [Test]
        public void DeleteAsync_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.DeleteAsync("Invalid ID"));
        }
        [Test]
        public async Task SetDiscountAsync_WorksCorrectly()
        {
            ProductDiscountViewModel vm = new ProductDiscountViewModel
            {
                Id = "c7ecd019-40b1-47f3-89c4-67e3625f796b",
                Discount = 10
            };

            await productService.SetDiscountAsync(vm);
            var proudct = dbContext.Products.FirstOrDefault(p => p.Id == Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b"));
            Assert.That(proudct.Discount == 10 && proudct.IsDiscounted == true, "SetDiscountAsync does not work");
        }
        [Test]
        public void SetDiscountAsync_ThrowsException()
        {
            ProductDiscountViewModel vm = new ProductDiscountViewModel
            {
                Id = "INVALID ID",
                Discount = 10
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.SetDiscountAsync(vm));

        }
        [Test]
        public async Task SetDiscountByCategoryAsync_WorksCorrectly()
        {
            await productService.SetDiscountByCategoryAsync("78355d47-6040-4676-9972-ac8be4f19882", 10);
            var products = dbContext.Products.Where(p => p.CategoryId == Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882")).ToList();
            Assert.That(products.All(p => p.Discount == 10 && p.IsDiscounted == true), "SetDiscountByCategoryAsync does not work");

        }
        [Test]
        public void SetDiscountByCategoryAsync_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.SetDiscountByCategoryAsync(null, 10), "SetDiscountByCategoryAsync doesnt throw exception when id is null");
        }
        [Test]
        public async Task RemoveDiscountAsync_WorksCorrectly()
        {
            await productService.RemoveDiscountAsync("c7ecd019-40b1-47f3-89c4-67e3625f796b");
            var product = dbContext.Products.FirstOrDefault(p => p.Id == Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b"));
            Assert.That(product.Discount == 0 && product.IsDiscounted == false, "RemoveDiscountAsync does not work");

        }
        [Test]
        public void RemoveDiscountAsync_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.RemoveDiscountAsync("Invalid ID"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.RemoveDiscountAsync(null));

        }
        [Test]
        public async Task DecreaseQuantityAsync_WorksCorrectly()
        {
            await productService.DecreaseQuantityAsync("c7ecd019-40b1-47f3-89c4-67e3625f796b");
            var product = dbContext.Products.FirstOrDefault(p => p.Id == Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b"));
            Assert.That(product.QuantityInStock == 81, "DecreaseQuantityAsync does not work");
        }
        [Test]
        public async Task IncreaseTotalOrdersAsync_WorksCorrectly()
        {
            await productService.IncreaseTotalOrdersAsync("c7ecd019-40b1-47f3-89c4-67e3625f796b", 3);
            var product = dbContext.Products.FirstOrDefault(p => p.Id == Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b"));
            Assert.That(product.TimesOrdered == 4, "IncreaseTotalOrdersAsync does not work");
        }
        [Test]
        public void IncreaseTotalOrdersAsync_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.IncreaseTotalOrdersAsync("Invalid ID", 3));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await productService.IncreaseTotalOrdersAsync(null, 3));
        }
        [Test]
        public async Task SearchAsync_WorksCorrectly()
        {
            var vm = await productService.SearchAsync("HoNeY");
            Assert.That(vm.Count() == 3, "SearchAsync does not work");
        }
        [TearDown]
        public void CleanUp()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}