using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Models.Entities;
using HoneyZoneMvc.Models.Entities.Enums;
using HoneyZoneMvc.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

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
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProduct(Product product)
        {
            var productToEdit = dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (productToEdit != null)
            {
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                productToEdit.Description = product.Description;
                productToEdit.ProductQuantity = product.ProductQuantity;
                productToEdit.Category = product.Category;
                productToEdit.QuantityInStock = product.QuantityInStock;
            }
            if (dbContext.SaveChanges()>0)
            {
                return true;
            }
            return false;
            
        }
    }
}
