using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
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
        Task<IEnumerable<ProductAdminViewModel>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<ProductCartViewModel>> GetUserCartAsync(string id);
        Task<ProductEditViewModel> GetProductEditByIdAsync(string Id);
        Task<bool> SetDiscountAsync(ProductDiscountViewModel vm);
        Task<bool> RemoveDiscountAsync(string Id);


    }
}
