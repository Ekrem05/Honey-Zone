using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IProductService
    {

        Task<bool> AddProductAsync(ProductAddViewModel product);
        Task<IEnumerable<ProductAdminViewModel>> GetAllProductsAsync();
        Task<bool> UpdateProductAsync(ProductEditViewModel product);
        Task<bool> DeleteProductAsync(string Id);
        Task<ProductAdminViewModel> GetProductByIdAsync(string Id);
        Task<IEnumerable<ProductAdminViewModel>> GetProductsByCategoryNameAsync(string category);
        Task<IEnumerable<ProductAdminViewModel>> GetProductsByCategoryIdAsync(string Id);
        Task<IEnumerable<ProductCartViewModel>> GetUserCartAsync(string id);
        Task<ProductEditViewModel> GetProductEditByIdAsync(string Id);
        Task<bool> SetDiscountAsync(ProductDiscountViewModel vm);
        Task<bool> RemoveDiscountAsync(string Id);
        Task DecreaseProductQuantityAsync(string Id);
        Task<bool> SetDiscountByCategoryAsync(string Id, double discount);

    }
}
