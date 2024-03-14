using HoneyZoneMvc.BusinessLogic.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IProductService
    {

        Task AddProductAsync(ProductAddViewModel product);
        Task<IEnumerable<ProductAdminViewModel>> GetAllProductsAsync();
        Task UpdateProductAsync(ProductEditViewModel product);
        Task DeleteProductAsync(string Id);
        Task<ProductAdminViewModel> GetProductByIdAsync(string Id);
        Task<IEnumerable<ProductAdminViewModel>> GetProductsByCategoryNameAsync(string category);
        Task<IEnumerable<ProductAdminViewModel>> GetProductsByCategoryIdAsync(string Id);
        Task SetDiscountAsync(ProductDiscountViewModel vm);
        Task RemoveDiscountAsync(string Id);
        Task DecreaseProductQuantityAsync(string Id);
        Task SetDiscountByCategoryAsync(string Id, double discount);
        Task<IEnumerable<ProductAdminViewModel>> SearchProductsAsync(string searchBy);
        Task<IEnumerable<ProductShopCardViewModel>> GetBestSellersAsync();
        Task IncreaseTotalOrdersAsync(string Id, int quantity);
    }
}
