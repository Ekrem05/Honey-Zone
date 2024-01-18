using HoneyZoneMvc.Models.Entities;

namespace HoneyZoneMvc.Contracts
{
    public interface IProductService
    {
        public bool AddProduct(Product product);
        public IEnumerable<Product> GetAllProducts();
        public bool UpdateProduct();
        public bool DeleteProduct();
        public Product GetProductById(int id);
    }
}
