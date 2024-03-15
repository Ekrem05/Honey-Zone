using HoneyZoneMvc.BusinessLogic.ViewModels.CartProduct;
using Microsoft.AspNetCore.Http;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICartProductService
    {

        Task DeleteCartProductAsync(IHttpContextAccessor httpContextAccessor);
        public Task<double> GetCartSumAsync(IHttpContextAccessor httpContextAccessor);
        Task AddOrUpdateCart(IHttpContextAccessor httpContextAccessor, string productId, int quantity);
        public Task<List<PostProductCartViewModel>> GetProductsFromCart(IHttpContextAccessor httpContextAccessor);


    }
}
