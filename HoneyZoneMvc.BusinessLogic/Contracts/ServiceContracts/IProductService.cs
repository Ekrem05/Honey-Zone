using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IProductService
    {

        Task<bool> AddProductAsync(ProductDto product);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<bool> UpdateProductAsync(ProductDto product);
        Task<bool> DeleteProductAsync(string Id);
        Task<ProductDto> GetProductByIdAsync(string Id);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<ProductCartViewModel>> GetUserCartAsync(string id);

    }
}
