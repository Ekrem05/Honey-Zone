using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Models.Entities;

namespace HoneyZoneMvc.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext dbContext;
        public ProductService(ApplicationDbContext _dbContext)
        {
                dbContext = _dbContext;
        }
        public bool AddProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }
            dbContext.Products.Add(product);
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
           
        }


        public bool DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
