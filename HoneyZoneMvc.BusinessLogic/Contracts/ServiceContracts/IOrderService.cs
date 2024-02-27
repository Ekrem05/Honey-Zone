﻿using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels.OrderViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IOrderService
    {
        Task<bool> AddAsync(string userId, double totalSum, string deliveryMethodId, OrderDetailDto orderDetailDto, List<OrderProduct> orderProducts);
        Task<IEnumerable<OrderInfoViewModel>> GetAllOrdersAsync();
        Task<IEnumerable<OrdersFromUserViewModel>> GetOrdersByUserIdAsync(string userId);
        Task<ChangeOrderStatusViewModel> GetOrderByIdAsync(string Id);
        Task ChangeStatusAsync(ChangeOrderStatusViewModel vm);
        Task DeleteOrder(string id);
        Task<OrderInfoViewModel> GetOrderDetailsAsync(string Id);

    }
}
