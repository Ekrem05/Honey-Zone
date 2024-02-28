using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductService productService;
        private readonly IStatusService stateService;
        private ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext _dbContext, IProductService _productService, IStatusService _serviceState)
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
                State = await stateService.GetInitialOrderStatus(),
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
        public async Task<bool> DeleteOrderAsync(string Id)
        {
            dbContext.OrderProducts.RemoveRange(dbContext.OrderProducts.Where(x => x.OrderId.ToString() == Id));
            dbContext.Orders.Remove(dbContext.Orders.FirstOrDefault(x => x.Id.ToString() == Id));
            return await dbContext.SaveChangesAsync()>0;
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<OrderInfoViewModel>> GetAllOrdersAsync()
        {
            var orders = await dbContext.Orders
                .Include(x => x.OrderDetail)
                .Include(x => x.DeliveryMethod)
                .Include(x => x.OrderProducts)
                .Include(x => x.State)
                .Select(x => new OrderInfoViewModel()
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

        public async Task<IEnumerable<OrdersFromUserViewModel>> GetUserOrdersIdAsync(string userId)
        {   
            List<OrdersFromUserViewModel>result=new List<OrdersFromUserViewModel>();
            var orders = await dbContext.Orders
                .Include(Id => Id.OrderDetail)
                .Include(Id => Id.DeliveryMethod)
                .Include(Id => Id.OrderProducts)
                .Include(Id => Id.State)
                .Where(o => o.ClientId == userId).ToListAsync();
            if (orders==null)
            {
                throw new Exception();
            }
            foreach (var order in orders)
            {
                var orderProducts = dbContext.OrderProducts.Where(x => x.OrderId.ToString() == order.Id.ToString()).Include(x => x.Product).ToList();
                result.Add(new OrdersFromUserViewModel()
                {
                    TotalSum = order.TotalSum.ToString(),
                    DeliveryMethod = order.DeliveryMethod.Name,
                    OrderDate = order.OrderDate.ToString(DataConstants.DateFormat),
                    ExpectedDelivery = order.ExpectedDelivery.ToString(DataConstants.DateFormat),
                    State = order.State.Name,
                    Address = order.OrderDetail.Address,
                    Products = orderProducts.Select(op => new ProductsOrderedUserViewModel()
                    {
                        Name = op.Product.Name,
                        Price = op.Product.Price.ToString(),
                        Quantity = op.Quantity.ToString(),
                        ProductAmount=op.Product.ProductAmount
                    }).ToList()
                });
            }
            return result;
        }

        public async Task<ChangeOrderStatusViewModel> GetOrderByIdAsync(string Id)
        {
            var order = await dbContext.Orders
                .Include(x => x.State)
                 .FirstOrDefaultAsync(x => x.Id.ToString() == Id);

            ChangeOrderStatusViewModel vm = new ChangeOrderStatusViewModel()
            {
                Id = order.Id.ToString(),
                CurrentStatus = order.State.Name,
            };

            vm.Statuses= await stateService.GetAllAsync();
            return vm;    
        }
        public async Task<OrderInfoViewModel> GetOrderDetailsAsync(string Id)
        {
            var order = await dbContext.Orders
                .Include(Id => Id.OrderDetail)
                .Include(Id => Id.DeliveryMethod)
                .Include(Id => Id.OrderProducts)
                .Include(Id => Id.State)
                .FirstOrDefaultAsync(o=>o.Id.ToString()==Id);
            var orderProducts=dbContext.OrderProducts.Where(x => x.OrderId.ToString() == Id).Include(x => x.Product).ToList();
            var result= new OrderInfoViewModel()
            {
                Id = order.Id.ToString(),
                TotalSum = order.TotalSum.ToString(),
                DeliveryMethod = order.DeliveryMethod.Name,
                OrderDate = order.OrderDate.ToString(DataConstants.DateFormat),
                State = order.State.Name,
                Address = order.OrderDetail.Address,
                PhoneNumber = order.OrderDetail.PhoneNumber,
                ClientName = order.OrderDetail.FirstName + " " + order.OrderDetail.SecondName,
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
            dbContext.Orders.FirstOrDefault(x => x.Id.ToString() == vm.Id).StateId = Guid.Parse(vm.StatusId);
             await dbContext.SaveChangesAsync();
        }
    }
}
