using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IProductService
    {

        Task<bool> AddProductAsync(ProductAddViewModel product);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<bool> UpdateProductAsync(ProductEditViewModel product);
        Task<bool> DeleteProductAsync(string Id);
        Task<ProductDto> GetProductByIdAsync(string Id);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<ProductCartViewModel>> GetUserCartAsync(string id);
        Task<ProductEditViewModel> GetProductEditByIdAsync(string Id);


    }
}
