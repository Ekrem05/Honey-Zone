using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Enums;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels.Order;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Tests
{
    public class OrderServiceTests
    {
        private IProductService productService;
        private IStatusService statusService;
        private IUserService userService;
        private ApplicationDbContext dbContext;

        private IOrderService orderService;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "HoneyZoneDb")
                .Options;

            dbContext = new ApplicationDbContext(options);
            productService = new Mock<IProductService>().Object;

            var statusServiceMock = new Mock<IStatusService>();
            statusServiceMock
              .Setup(x => x.GetInitialOrderStatus()).ReturnsAsync(new Status() { Name = "Test Status" });

            statusService = statusServiceMock.Object;
            userService = new Mock<IUserService>().Object;
            
            orderService= new OrderService(dbContext, productService, statusService, userService);
        }
        [SetUp]
        public void SeedData()
        {
            dbContext.Statuses.AddRange(SeedStatus());
            dbContext.Users.AddRange(SeedUsers());
            dbContext.DeliverMethods.AddRange(SeedDeliverMethods());
            dbContext.Orders.AddRange(SeedOrders());

            dbContext.SaveChanges();
        }


        [Test]
        public async Task AddOrderAsync_ShouldAddOrder()
        {

            var order = new OrderAddViewModel()
            {
                ClientId = "32788ce0-a18e-4426-9f0c-f018e3b45bbe",
                OrderDate = DateTime.Now,
                TotalSum = 99,
                DeliveryMethodId = "370957e2-66f3-43ba-8e11-8bb1cd2da596",
                OrderProducts = new List<OrderProduct>()
                {
                    new OrderProduct()
                    {
                        ProductId = Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                        Quantity = 2
                    }
                },
                OrderDetail = new OrderDetailViewModel()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    Address = "Test Address",
                    City = "Test City",
                    PhoneNumber = "Test",
                    ZipCode = "Test",
                    Email = "Test@gmail",
                },

            };
            await orderService.AddAsync(order);
            var result = dbContext.Orders.FirstOrDefault(x => x.ClientId == Guid.Parse("32788ce0-a18e-4426-9f0c-f018e3b45bbe"));
            Assert.IsNotNull(result);
            Assert.AreEqual(99, result.TotalSum);
            Assert.AreEqual(1, result.OrderProducts.Count());
            Assert.AreEqual("Test Status", result.Status.Name);

        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteOrder()
        {
            var order = dbContext.Orders.FirstOrDefault();
            await orderService.DeleteAsync(order.Id.ToString());
            var result = dbContext.Orders.FirstOrDefault(x => x.Id == order.Id);
            Assert.IsNull(result);
        }
        [Test]
        public void DeleteAsync_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => orderService.DeleteAsync(null));
            Assert.ThrowsAsync<InvalidOperationException>(() => orderService.DeleteAsync(Guid.NewGuid().ToString()));
        }
        [Test]
        public async Task OrderSorting_ShouldSortOrders()
        {
            var all=dbContext.Orders.ToList();
            var orders=await orderService.AllAsync(0,0,0, null, OrderSorting.TotalSum, 1, 3);
            Assert.AreEqual(2, orders.Orders.Count());
            Assert.AreEqual(100, double.Parse(orders.Orders.First().TotalSum));

            orders = await orderService.AllAsync(25, 2, 2023, null, OrderSorting.Date, 1, 3);
            Assert.AreEqual(1, orders.Orders.Count());
            Assert.AreEqual(27.77, double.Parse(orders.Orders.First().TotalSum));
            orders = await orderService.AllAsync(0, 0, 0, "AleX", OrderSorting.Date, 1, 3);
            Assert.AreEqual(1, orders.Orders.Count());
            orders = await orderService.AllAsync(0, 0, 0, "IvAnov", OrderSorting.Date, 1, 3);
            Assert.AreEqual(1, orders.Orders.Count());
            orders = await orderService.AllAsync(0, 0, 0, "0888888888", OrderSorting.Date, 1, 3);
            Assert.AreEqual(1, orders.Orders.Count());
            orders = await orderService.AllAsync(0, 0, 0,null, 0, 1, 3);
            Assert.AreEqual(100, double.Parse(orders.Orders.First().TotalSum));
        }
        [Test]
        public async Task AllAsync_ShouldReturnAllOrders()
        {
            var orders = await orderService.AllAsync();
            Assert.AreEqual(2, orders.Count());
        }
        [Test]
        public async Task OrdersByUserIdAsync_ShouldWorkCorrectly()
        {
            var orders = await orderService.OrdersByUserIdAsync("59d88877-cbc5-4b48-ab0c-5b9bfc89a512");
            Assert.AreEqual(1, orders.Count());
        }
        [Test]
        public void OrdersByUserIdAsync_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => orderService.OrdersByUserIdAsync(null));
        }
        [Test]
        public async Task OrderByIdAsync_ShouldReturnOrder()
        {
            var order = await orderService.OrderByIdAsync(dbContext.Orders.FirstOrDefault().Id.ToString());
            Assert.IsNotNull(order);
        }
        [Test]
        public void OrderByIdAsync_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => orderService.OrderByIdAsync(null));
            Assert.ThrowsAsync<InvalidOperationException>(() => orderService.OrderByIdAsync(Guid.NewGuid().ToString()));
        }
        [Test]
        public async Task DetailsAsync_ShouldReturnOrderDetails()
        {
            var order = await orderService.DetailsAsync("1625dc3c-9673-48be-a1af-8011c01f3735");
            var orderproducts = dbContext.OrderProducts.ToList();
            Assert.IsNotNull(order);
            Assert.IsTrue(order.Products.Count() > 0);
            Assert.AreEqual("Test", order.PhoneNumber);
        }
        [Test]
        public void DetailsAsync_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => orderService.DetailsAsync(null));
            Assert.ThrowsAsync<InvalidOperationException>(() => orderService.DetailsAsync(Guid.NewGuid().ToString()));
        }
        [Test]
        public async Task ChangeStatusAsync_ShouldChangeStatus()
        {
            var order = dbContext.Orders.FirstOrDefault(X=>X.Id==Guid.Parse("1625dc3c-9673-48be-a1af-8011c01f3735"));
            var status = new ChangeOrderStatusViewModel()
            {
                Id = "1625dc3c-9673-48be-a1af-8011c01f3735",
                StatusId= "22258d7b-33f7-4574-b0ea-4cf5d564bb6e"
            };
            await orderService.ChangeStatusAsync(status);
            var result = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Guid.Parse("1625dc3c-9673-48be-a1af-8011c01f3735"));
            Assert.That("TEST STATUS", Is.EqualTo(result.Status.Name));
        }
        [Test]
        public void ChangeStatusAsync_ShouldThrowException()
        {
            var status = new ChangeOrderStatusViewModel()
            {
                Id = "INVALID ID",
                StatusId = Guid.NewGuid().ToString()
            };
            Assert.ThrowsAsync<ArgumentNullException>(() => orderService.ChangeStatusAsync(new ChangeOrderStatusViewModel() {Id=null }));
            Assert.ThrowsAsync<InvalidOperationException>(() => orderService.ChangeStatusAsync(status));
        }

        [TearDown]
        public void CleanData()
        {
            dbContext.Orders.RemoveRange(dbContext.Orders);
            dbContext.Users.RemoveRange(dbContext.Users);
            dbContext.Statuses.RemoveRange(dbContext.Statuses);
            dbContext.DeliverMethods.RemoveRange(dbContext.DeliverMethods);
            dbContext.SaveChanges();
        }

        private Order[] SeedOrders()
        {
            DateTime dateTime1 = new DateTime(2023, 2, 25);
            DateTime dateTime2 = new DateTime(2022, 7, 1);

            return new Order[]
            {
                new Order()
                {  
                    Id=Guid.Parse("1625dc3c-9673-48be-a1af-8011c01f3735"),
                    Client= new ApplicationUser()
                    {
                        FirstName="Test",
                        LastName="Test",
                        Email="Test@gmail",
                        UserName="Test",
                        PasswordHash="Test",
                    },
                    StatusId=Guid.Parse("22258d7b-33f7-4574-b0ea-4cf5d564bb6e"),
                    OrderDate = dateTime1,
                    ExpectedDelivery = DateTime.Now.AddDays(5),
                    TotalSum = 27.77,
                    OrderProducts = new List<OrderProduct>()
                    {
                        new OrderProduct()
                        { 
                            Product=new Product(){
                                Id=Guid.NewGuid(),
                                Name="Sunflower Honey"
                            },
                            Quantity = 2
                        }
                    },
                    OrderDetail=new OrderDetail()
                    {
                        FirstName="Test",
                        LastName="Test",
                        Address="Test Address",
                        City="Test City",
                        PhoneNumber="Test",
                        ZipCode="Test",
                        Email="Test@gmail",
                    },
                    DeliveryMethodId= Guid.Parse("370957e2-66f3-43ba-8e11-8bb1cd2da596")
                },
                 new Order()
                {
                    ClientId=Guid.Parse("59d88877-cbc5-4b48-ab0c-5b9bfc89a512"),
                    Status=new Status()
                    {
                        Name="Test Status"
                    },
                    OrderDate = dateTime2,
                    ExpectedDelivery = DateTime.Now.AddDays(5),
                    TotalSum = 100,
                    OrderProducts = new List<OrderProduct>()
                    {
                        new OrderProduct()
                        {
                            ProductId = Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                            Quantity = 2
                        }
                    },
                    OrderDetail=new OrderDetail()
                    {
                        FirstName="Alex Test",
                        LastName="Ivanov Test",
                        Address="Test Address",
                        City="Test City",
                        PhoneNumber="0888888888",
                        ZipCode="Test",
                        Email="Test@gmail",
                    },
                    DeliveryMethodId= Guid.Parse("370957e2-66f3-43ba-8e11-8bb1cd2da596")
                }
            };
        }

        private ApplicationUser[] SeedUsers()
        {
           return new ApplicationUser[]
           {
               new ApplicationUser()
               {
                   Id=Guid.Parse("59d88877-cbc5-4b48-ab0c-5b9bfc89a512"),
                   FirstName="Test",
                   LastName="Test",
                   Email="Test@gmail",
                   UserName="Test",
                   PasswordHash="Test",
               },
               new ApplicationUser()
               {
                   Id=Guid.Parse("32788ce0-a18e-4426-9f0c-f018e3b45bbe"),
                   FirstName="Test",
                   LastName="Test",
                   Email="Test@gmail",
                   UserName="Test",
                   PasswordHash="Test",
               }
           };
        }

        private DeliveryMethod[] SeedDeliverMethods()
        {
            return new DeliveryMethod[]
            {
                new DeliveryMethod()
                {
                    Id=Guid.Parse("370957e2-66f3-43ba-8e11-8bb1cd2da596"),
                    Name="Test",
                }
            };
        }
        private Status[] SeedStatus()
        {
            return new Status[]
            {
                new Status()
                {
                    Id=Guid.Parse("22258d7b-33f7-4574-b0ea-4cf5d564bb6e"),
                    Name="TEST STATUS",
                }
            };
        }
    }
}
