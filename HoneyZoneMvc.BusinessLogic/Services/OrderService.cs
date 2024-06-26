﻿using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Enums;
using HoneyZoneMvc.BusinessLogic.ViewModels.Order;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;
using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductService productService;
        private readonly IStatusService statusService;
        private readonly IUserService userService;
        private ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext _dbContext,
            IProductService _productService,
            IStatusService _serviceState,
            IUserService _userService
            )
        {
            dbContext = _dbContext;
            productService = _productService;
            statusService = _serviceState;
            userService = _userService;
        }

        public async Task AddAsync(OrderAddViewModel vm)
        {
            await dbContext.Orders.AddAsync(new Order()
            {
                ClientId = Guid.Parse(vm.ClientId),
                TotalSum = vm.TotalSum,
                DeliveryMethodId = Guid.Parse(vm.DeliveryMethodId),
                OrderDate = vm.OrderDate,
                Status = await statusService.GetInitialOrderStatus(),
                ExpectedDelivery = DateTime.Now.AddDays(3),
                OrderDetail = new OrderDetail()
                {
                    FirstName = vm.OrderDetail.FirstName,
                    LastName = vm.OrderDetail.LastName,
                    PhoneNumber = vm.OrderDetail.PhoneNumber,
                    Email = vm.OrderDetail.Email,
                    Address = vm.OrderDetail.Address,
                    City = vm.OrderDetail.City,
                    ZipCode = vm.OrderDetail.ZipCode
                },
                OrderProducts = vm.OrderProducts

            });
            foreach (var item in vm.OrderProducts)
            {
                await productService.IncreaseTotalOrdersAsync(item.ProductId.ToString(), item.Quantity);
                await productService.DecreaseQuantityAsync(item.ProductId.ToString());
            }
            await userService.AddUserToRoleAsync(nameof(Roles.Client), vm.ClientId);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(IdNull);
            }
            Order order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id.ToString() == Id);
            if (order == null)
            {
                throw new InvalidOperationException(OrderMessages.OrderNotFound);
            }
            dbContext.OrderProducts.RemoveRange(dbContext.OrderProducts.Where(x => x.OrderId.ToString() == Id));
            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// This method is used to get all orders with pagination and search functionality
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="searchTerm"></param>
        /// <param name="sorting"></param>
        /// <param name="currentPage"></param>
        /// <param name="ordersPerPage"></param>
        /// <returns></returns>
        public async Task<AllOrdersQueryModel> AllAsync(int day = 0, int month = 0, int year = 0,
            string? searchTerm = null,
            OrderSorting sorting = OrderSorting.Date,
            int currentPage = 1,
            int ordersPerPage = 1)
        {
            var orders = dbContext.Orders
                .Include(x => x.OrderDetail)
                .Include(x => x.DeliveryMethod)
                .Include(x => x.Status)
                .AsQueryable();
            if (day > 0)
            {
                orders = orders.Where(o => o.OrderDate.Day == day);
            }
            if (month > 0)
            {
                orders = orders.Where(o => o.OrderDate.Month == month);
            }
            if (year > 0)
            {
                orders = orders.Where(o => o.OrderDate.Year == year);
            }
            if (searchTerm != null)
            {
                orders = orders.Where(x =>
                x.OrderDetail.FirstName
                .ToLower().Contains(searchTerm.ToLower()) ||
                x.OrderDetail.LastName
                .ToLower().Contains(searchTerm.ToLower()) ||
                x.OrderDetail.PhoneNumber.StartsWith(searchTerm)
                );
            }
            orders = sorting switch
            {
                OrderSorting.Date => orders.OrderBy(x => x.OrderDate),
                OrderSorting.TotalSum => orders.OrderByDescending(x => x.TotalSum),
                _ => orders.OrderByDescending(x => x.OrderDate)
            };
            var ordersToShow = await orders
               .Skip((currentPage - 1) * ordersPerPage)
               .Take(ordersPerPage)
               .ToListAsync();

            return new AllOrdersQueryModel()
            {
                TotalOrdersCount = orders.Count(),
                Orders = ordersToShow.Select(x => new OrderAdminViewModel()
                {
                    Id = x.Id.ToString(),
                    TotalSum = x.TotalSum.ToString(),
                    DeliveryMethod = x.DeliveryMethod.Name,
                    ClientName = x.OrderDetail.FirstName + " " + x.OrderDetail.LastName,
                    OrderDate = x.OrderDate.ToString(DataConstants.DateFormat),
                    Address = x.OrderDetail.Address,
                    PhoneNumber = x.OrderDetail.PhoneNumber,
                    ExpectedDelivery = x.ExpectedDelivery.ToString(DataConstants.DateFormat),
                    State = x.Status.Name
                }).ToList()
            };


        }

        public async Task<IEnumerable<OrderViewModel>> AllAsync()
        {
            var orders = await dbContext.Orders
                .Include(x => x.OrderDetail)
                .Include(x => x.DeliveryMethod)
                .Include(x => x.OrderProducts)
                .Include(x => x.Status)
                .Select(x => new OrderViewModel()
                {
                    Id = x.Id.ToString(),
                    TotalSum = x.TotalSum.ToString(),
                    DeliveryMethod = x.DeliveryMethod.Name,
                    OrderDate = x.OrderDate.ToString(DataConstants.DateFormat),
                    State = x.Status.Name,
                    Address = x.OrderDetail.Address,
                    PhoneNumber = x.OrderDetail.PhoneNumber,
                    ClientName = x.OrderDetail.FirstName + " " + x.OrderDetail.LastName,
                    ExpectedDelivery = x.ExpectedDelivery.ToString(DataConstants.DateFormat),
                }).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<OrdersFromUserViewModel>> OrdersByUserIdAsync(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(IdNull);
            }
            List<OrdersFromUserViewModel> result = new List<OrdersFromUserViewModel>();
            var orders = await dbContext.Orders
                .Include(Id => Id.OrderDetail)
                .Include(Id => Id.DeliveryMethod)
                .Include(Id => Id.OrderProducts)
                .Include(Id => Id.Status)
                .Where(o => o.ClientId.ToString() == userId).ToListAsync();
            foreach (var order in orders)
            {
                var orderProducts = dbContext.OrderProducts.Where(x => x.OrderId.ToString() == order.Id.ToString()).Include(x => x.Product).ToList();
                result.Add(new OrdersFromUserViewModel()
                {
                    TotalSum = order.TotalSum.ToString(),
                    DeliveryMethod = order.DeliveryMethod.Name,
                    OrderDate = order.OrderDate.ToString(DataConstants.DateFormat),
                    ExpectedDelivery = order.ExpectedDelivery.ToString(DataConstants.DateFormat),
                    State = order.Status.Name,
                    Address = order.OrderDetail.Address,
                    Products = orderProducts.Select(op => new ProductsOrderedUserViewModel()
                    {
                        Name = op.Product.Name,
                        Price = op.Product.Price.ToString(),
                        IsDiscounted = op.Product.IsDiscounted,
                        DiscountedPrice = (op.Product.Price - (op.Product.Price * op.Product.Discount / 100)).ToString("F2"),
                        Quantity = op.Quantity.ToString(),
                        ProductAmount = op.Product.ProductAmount
                    }).ToList()
                });
            }
            return result;
        }

        public async Task<ChangeOrderStatusViewModel> OrderByIdAsync(string Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(IdNull);
            }
            var order = await dbContext.Orders
                .Include(x => x.Status)
                 .FirstOrDefaultAsync(x => x.Id.ToString() == Id);
            if (order == null)
            {
                throw new InvalidOperationException(OrderMessages.OrderNotFound);
            }
            ChangeOrderStatusViewModel vm = new ChangeOrderStatusViewModel()
            {
                Id = order.Id.ToString(),
                CurrentStatus = order.Status.Name,
            };

            vm.Statuses = await statusService.AllAsync();
            return vm;
        }

        public async Task<OrderViewModel> DetailsAsync(string Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(IdNull);
            }
            var order = await dbContext.Orders
                .Include(Id => Id.OrderDetail)
                .Include(Id => Id.DeliveryMethod)
                .Include(Id => Id.OrderProducts)
                .Include(Id => Id.Status)
                .FirstOrDefaultAsync(o => o.Id.ToString() == Id);
            if (order == null)
            {
                throw new InvalidOperationException(OrderMessages.OrderNotFound);
            }
            var orderProducts = dbContext.OrderProducts.Where(x => x.OrderId.ToString() == Id).Include(x => x.Product).ToList();
            var result = new OrderViewModel()
            {
                Id = order.Id.ToString(),
                TotalSum = order.TotalSum.ToString(),
                DeliveryMethod = order.DeliveryMethod.Name,
                OrderDate = order.OrderDate.ToString(DataConstants.DateFormat),
                State = order.Status.Name,
                Address = order.OrderDetail.Address,
                PhoneNumber = order.OrderDetail.PhoneNumber,
                ClientName = order.OrderDetail.FirstName + " " + order.OrderDetail.LastName,
                ExpectedDelivery = order.ExpectedDelivery.ToString(DataConstants.DateFormat),
                Products = orderProducts.Select(op => new ProductOrderedAdminViewModel()
                {
                    Id = op.Product.Id.ToString(),
                    Name = op.Product.Name,
                    Price = op.Product.Price.ToString(),
                    Quantity = op.Quantity.ToString()
                }).ToList()
            };
            return result;
        }

        public async Task ChangeStatusAsync(ChangeOrderStatusViewModel vm)
        {
            if (vm.Id == null)
            {
                throw new ArgumentNullException(IdNull);
            }
            var order = dbContext.Orders.FirstOrDefault(x => x.Id.ToString() == vm.Id);
            if (order == null)
            {
                throw new InvalidOperationException(OrderMessages.OrderNotFound);
            }
            var status = await statusService.GetByIdAsync(vm.StatusId);

            order.StatusId = Guid.Parse(vm.StatusId);
            await dbContext.SaveChangesAsync();
        }

    }
}