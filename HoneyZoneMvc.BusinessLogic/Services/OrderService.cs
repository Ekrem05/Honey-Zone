using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductService productService;
        private readonly IStateService stateService;
        private ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext _dbContext, IProductService _productService, IStateService _serviceState)
        {
            dbContext = _dbContext;
            productService = _productService;
            stateService = _serviceState;
        }

        public async Task<bool> AddAsync(string userId, double totalSum, string deliveryMethodId, OrderDetailDto orderDetailDto, List<OrderProduct> orderProducts)
        {
            await dbContext.Orders.AddAsync(new Order()
            {
                ClientId = userId,
                TotalSum = totalSum,
                DeliveryMethodId = Guid.Parse(deliveryMethodId),
                OrderDate = DateTime.Now,
                State = await stateService.GetInitialOrderState(),
                ExpectedDelivery = DateTime.Now.AddDays(4),
                OrderDetail = new OrderDetail()
                {
                    FirstName = orderDetailDto.FirstName,
                    SecondName = orderDetailDto.SecondName,
                    PhoneNumber = orderDetailDto.PhoneNumber,
                    Email = orderDetailDto.Email,
                    Address = orderDetailDto.Address,
                    Country = orderDetailDto.Country,
                    ZipCode = orderDetailDto.ZipCode
                },
                OrderProducts = orderProducts

            });
            return await dbContext.SaveChangesAsync() > 0;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<OrderBasicsViewModel>> GetAllOrdersAsync()
        {
            var orders = await dbContext.Orders
                .Include(x => x.OrderDetail)
                .Include(x => x.DeliveryMethod)
                .Include(x => x.OrderProducts)
                .Include(x => x.State)
                .Select(x => new OrderBasicsViewModel()
                {
                    Id = x.Id.ToString(),
                    TotalSum = x.TotalSum.ToString(),
                    DeliveryMethod = x.DeliveryMethod.Name,
                    OrderDate = x.OrderDate.ToString(DataConstants.DateFormat),
                    State = x.State.Name,
                    Address = x.OrderDetail.Address,
                    PhoneNumber = x.OrderDetail.PhoneNumber,
                    ClientName = x.OrderDetail.FirstName + " " + x.OrderDetail.SecondName,
                    ExpectedDelivery = x.ExpectedDelivery.ToString(DataConstants.DateFormat),
                }).ToListAsync();
            return orders;
        }
        public async Task<IEnumerable<OrdersFromUserViewModel>> GetOrdersByUserIdAsync(string userId)
        {
            return await dbContext.Orders
                .Include(x => x.OrderDetail)
                .Include(x => x.DeliveryMethod)
                .Include(x => x.OrderProducts)
                .Include(x => x.State)
                .Where(x => x.ClientId == userId)
                .Select(x => new OrdersFromUserViewModel()
                {
                   
                    TotalSum = x.TotalSum.ToString(),
                    DeliveryMethod = x.DeliveryMethod.Name,
                    OrderDate = x.OrderDate.ToString(DataConstants.DateFormat),
                    State = x.State.Name,
                    Address = x.OrderDetail.Address,
                    ExpectedDelivery = x.ExpectedDelivery.ToString(DataConstants.DateFormat),
                }).ToListAsync();
        }
    }
}
