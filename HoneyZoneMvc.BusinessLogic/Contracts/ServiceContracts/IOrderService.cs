﻿using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IOrderService
    {
        Task<bool> AddAsync(string userId, double totalSum, string deliveryMethodId, OrderDetailDto orderDetailDto, List<OrderProduct> orderProducts);
        Task<IEnumerable<OrderInfoViewModel>> GetAllOrdersAsync();
        Task<IEnumerable<OrdersFromUserViewModel>> GetUserOrdersIdAsync(string userId);
        Task<ChangeOrderStatusViewModel> GetOrderByIdAsync(string Id);
        Task ChangeStatusAsync(ChangeOrderStatusViewModel vm);
        Task<bool> DeleteOrderAsync(string Id);
        Task<OrderInfoViewModel> GetOrderDetailsAsync(string Id);

    }
}
