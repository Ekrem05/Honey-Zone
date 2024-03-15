using HoneyZoneMvc.BusinessLogic.ViewModels.CartProduct;
using Microsoft.AspNetCore.Http;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICartProductService
    {

        Task DeleteAsync(IHttpContextAccessor httpContextAccessor);
        public Task<double> CartSumAsync(IHttpContextAccessor httpContextAccessor);
        Task AddOrUpdateCart(IHttpContextAccessor httpContextAccessor, string productId, int quantity);
        public Task<List<PostProductCartViewModel>> ProductsFromCart(IHttpContextAccessor httpContextAccessor);


    }
}
