using HoneyZoneMvc.Infrastructure.ViewModels.CartProduct;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICartProductService
    {

        Task<bool> AddCartProductAsync(CartProductViewModel dto);
        Task<bool> UpdateQuantityAsync(string productId, int quantity, string userId);
        Task<IEnumerable<CartProductViewModel>> GetCartByUserIdAsync(string userId);
        Task<bool> DeleteCartProductAsync(string userId);
        Task<double> GetCartSumAsync(string userId);
    }
}
