using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.BusinessLogic.ViewModels.Order;
using HoneyZoneMvc.BusinessLogic.Enums;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IOrderService
    {
        Task AddAsync(string userId, double totalSum, string deliveryMethodId, OrderDetailViewModel orderDetailDto, List<OrderProduct> orderProducts);
        Task<IEnumerable<Order>> AllAsync();
        Task<AllOrdersQueryModel> AllAsync(int day, int month, int year, string? searchTerm, OrderSorting sorting, int currentPage, int ordersPerPage);
        Task<IEnumerable<OrdersFromUserViewModel>> OrdersByUserIdAsync(string userId);
        Task<ChangeOrderStatusViewModel> OrderByIdAsync(string Id);
        Task ChangeStatusAsync(ChangeOrderStatusViewModel vm);
        Task DeleteAsync(string Id);
        Task<OrderInfoViewModel> DetailsAsync(string Id);

    }
}
