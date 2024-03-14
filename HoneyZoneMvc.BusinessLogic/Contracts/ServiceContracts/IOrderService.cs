using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.BusinessLogic.ViewModels.OrderViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IOrderService
    {
        Task AddAsync(string userId, double totalSum, string deliveryMethodId, OrderDetailViewModel orderDetailDto, List<OrderProduct> orderProducts);
        Task<IEnumerable<OrderInfoViewModel>> GetAllOrdersAsync();
        Task<IEnumerable<OrdersFromUserViewModel>> GetUserOrdersIdAsync(string userId);
        Task<ChangeOrderStatusViewModel> GetOrderByIdAsync(string Id);
        Task ChangeStatusAsync(ChangeOrderStatusViewModel vm);
        Task DeleteOrderAsync(string Id);
        Task<OrderInfoViewModel> GetOrderDetailsAsync(string Id);

    }
}
