using HoneyZoneMvc.Infrastructure.ViewModels.CartProduct;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICartProductService
    {

        Task AddCartProductAsync(CartProductViewModel dto);
        Task UpdateQuantityAsync(string productId, int quantity, string userId);
        Task<IEnumerable<CartProductViewModel>> GetCartByUserIdAsync(string userId);
        Task DeleteCartProductAsync(string userId);
        Task<double> GetCartSumAsync(string userId);
    }
}
