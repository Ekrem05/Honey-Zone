using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;

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
        Task<IEnumerable<ProductCartViewModel>> GetUserCartAsync(string id);
        Task<ProductEditViewModel> GetProductEditByIdAsync(string Id);
        Task SetDiscountAsync(ProductDiscountViewModel vm);
        Task RemoveDiscountAsync(string Id);
        Task DecreaseProductQuantityAsync(string Id);
        Task SetDiscountByCategoryAsync(string Id, double discount);

    }
}
