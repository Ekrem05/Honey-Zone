
using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Messages;
using HoneyZoneMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace HoneyZoneMvc.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext dbContext;
        private ICategoryService categoryService;

        public ProductService(ApplicationDbContext _dbContext,ICategoryService _categoryService)
        {
                dbContext = _dbContext;
                categoryService = _categoryService;
        }
        public async Task<bool> AddProductAsync(ProductDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.ArgumentNull, nameof(ProductDto)));
            }
            Product productToAdd = new Product() {
                Name = product.Name,
                Category=dbContext.Categories.FirstOrDefault(c => c.Name == product.Category),
                Price = product.Price,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductQuantity = product.ProductQuantity,
                MainImageName = product.MainImageFile.FileName
            };
            await dbContext.Products.AddAsync(productToAdd);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            
            return false;
           
        }

        public async Task<bool> DeleteProductAsync(int Id)
        {
            var product=await dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenId, Id));

            }
            dbContext.Remove(product);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;

        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var models=await dbContext.Products.ToListAsync();
            List<ProductDto> productsDto = new List<ProductDto>();
           
            foreach (var product in models)
            {
                productsDto.Add(new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    QuantityInStock = product.QuantityInStock,
                    ProductQuantity = product.ProductQuantity,
                    Category = product.Category.Name,
                    MainImageName = product.MainImageName
                });
            }
            return productsDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category)
        {
            if (category.ToUpper()=="ALL")
            {
                return await GetAllProductsAsync();

            }
            var models = await GetAllProductsAsync();
            var result = models.Where(p => p.Category == category).ToList();
            if (result != null)
            {
                List<ProductDto> productsDto = new List<ProductDto>();
                foreach (var product in result)
                {
                    productsDto.Add(new ProductDto()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description,
                        QuantityInStock = product.QuantityInStock,
                        ProductQuantity = product.ProductQuantity,
                        Category = product.Category,
                        MainImageName = product.MainImageName
                    });
                }
                return productsDto;
            }
            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenCategory,category));
           
        }

        public async Task<ProductDto> GetProductByIdAsync(int Id)
        {
            var models = await GetAllProductsAsync();
            var model=models.ToList().FirstOrDefault(p => p.Id == Id);
            if (model != null)
            {
                return model;
            }


            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenId, Id));
        }

        public async Task<bool> UpdateProductAsync(ProductDto product)
        {
            var productToEdit = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (productToEdit != null)
            {
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                productToEdit.Description = product.Description;
                productToEdit.ProductQuantity = product.ProductQuantity;
                productToEdit.Category = dbContext.Categories.FirstOrDefault(c => c.Name == product.Category);
                productToEdit.QuantityInStock = product.QuantityInStock;
                productToEdit.MainImageName = product.MainImageFile.FileName;
                productToEdit.ImageNames= product.ImagesNames;
            }
            if (dbContext.SaveChanges()>0)
            {
                return true;
            }
            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenId, product.Id));

        }
    }
}
