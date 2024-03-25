using HoneyZoneMvc.BusinessLogic.ViewModels.CartProduct;
using Microsoft.AspNetCore.Http;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICartProductService
    {

        Task DeleteAsync(IHttpContextAccessor httpContextAccessor);
        Task<double> CartSumAsync(IHttpContextAccessor httpContextAccessor);
        Task AddCartAsync(IHttpContextAccessor httpContextAccessor, string productId, int quantity);
        Task UpdateCartAsync(IHttpContextAccessor httpContextAccessor, List<PostProductCartViewModel> cart);
        Task<List<PostProductCartViewModel>> ProductsFromCartAsync(IHttpContextAccessor httpContextAccessor);
        Task RemoveProductFromCartAsync(IHttpContextAccessor httpContextAccessor, string id);



    }
}
