using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductService productService;
        private readonly IStateService stateService;
        private ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext _dbContext, IProductService _productService,IStateService _serviceState)
        {
            dbContext = _dbContext;
            productService= _productService;
            stateService= _serviceState;
        }

        public async Task<bool> AddAsync(string userId, double totalSum, string deliveryMethodId, OrderDetailDto orderDetailDto, List<OrderProduct> orderProducts)
        {
            await dbContext.Orders.AddAsync(new Order()
            {
                ClientId = userId,
                TotalSum = totalSum,
                DeliveryMethodId =Guid.Parse(deliveryMethodId),
                OrderDate = DateTime.Now,
                State = await stateService.GetInitialOrderState(),
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
            return await dbContext.SaveChangesAsync()>0;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }

    }
}
