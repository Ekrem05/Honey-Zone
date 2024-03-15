﻿using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.BusinessLogic.ViewModels.Order;
using HoneyZoneMvc.BusinessLogic.Enums;
using HoneyZoneMvc.BusinessLogic.Contracts.SubContracts;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IOrderService:IAddable<OrderAddViewModel>
        ,IDeletable
    {
        Task<AllOrdersQueryModel> AllAsync(int day, int month, int year, string? searchTerm, OrderSorting sorting, int currentPage, int ordersPerPage);
        Task<IEnumerable<OrdersFromUserViewModel>> OrdersByUserIdAsync(string userId);
        Task<ChangeOrderStatusViewModel> OrderByIdAsync(string Id);
        Task ChangeStatusAsync(ChangeOrderStatusViewModel vm);     
        Task<OrderInfoViewModel> DetailsAsync(string Id);

    }
}
