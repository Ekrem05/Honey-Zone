using HoneyZoneMvc.Models.Entities;

namespace HoneyZoneMvc.Contracts
{
    public interface IProductService
    {

        public bool AddProduct(Product product);
        public IEnumerable<Product> GetAllProducts();
        public bool UpdateProduct(Product product);
        public bool DeleteProduct();
        public Product GetProductById(int id);
        public IEnumerable<Product> GetProductsByCategory(string category);

    }
}
