using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.Contracts
{
    public interface IProductService
    {

         Task<bool> AddProductAsync(ProductDto product);
         Task<IEnumerable<ProductDto>> GetAllProductsAsync();
         Task<bool> UpdateProductAsync(ProductDto product);
         Task<bool> DeleteProductAsync(int Id);
         Task<ProductDto> GetProductByIdAsync(int Id);
         Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category);

    }
}
