using HoneyZoneMvc.BusinessLogic.ViewModels.CartProduct;
using Microsoft.AspNetCore.Http;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICartProductService
    {

        Task DeleteAsync(IHttpContextAccessor httpContextAccessor);
        Task<double> CartSumAsync(IHttpContextAccessor httpContextAccessor);
        Task AddOrUpdateCart(IHttpContextAccessor httpContextAccessor, string productId, int quantity);
        Task<List<PostProductCartViewModel>> ProductsFromCart(IHttpContextAccessor httpContextAccessor);
        Task RemoveProductFromCart(IHttpContextAccessor httpContextAccessor, string id);



    }
}
