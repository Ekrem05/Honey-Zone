
using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Messages;
using HoneyZoneMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext dbContext;
        private ICategoryService categoryService;

        public ProductService(ApplicationDbContext _dbContext, ICategoryService _categoryService)
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
            Product productToAdd = await TransformProduct(product);
            await dbContext.Products.AddAsync(productToAdd);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;

        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var models = await dbContext.Products
                .Include(p => p.Category)
                .ToListAsync();

            List<ProductDto> productsDto = new List<ProductDto>();

            foreach (var product in models)
            {
                productsDto.Add(TransformProduct(product));
            }
            return productsDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category)
        {
            if (category.ToUpper() == "ALL")
            {
                return await GetAllProductsAsync();

            }

            var models = await dbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name == category)
                .ToListAsync();

            if (models != null)
            {
                List<ProductDto> productsDto = new List<ProductDto>();
                foreach (var product in models)
                {
                    productsDto.Add(TransformProduct(product));
                }
                return productsDto;
            }
            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenCategory, category));

        }

        public async Task<ProductDto> GetProductByIdAsync(string Id)
        {
            var model = await dbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id.ToString()==Id);

            if (model != null)
            {
                return TransformProduct(model);
            }


            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenId, Id));
        }

        public async Task<bool> UpdateProductAsync(ProductDto product)
        {
            var productToEdit = await dbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (productToEdit != null)
            {
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                productToEdit.Description = product.Description;
                productToEdit.ProductAmount = product.ProductAmount;
                productToEdit.Category = dbContext.Categories.FirstOrDefault(c => c.Name == product.Category);
                productToEdit.QuantityInStock = product.QuantityInStock;
                productToEdit.MainImageName = product.MainImageName;
                productToEdit.ImageNames = product.ImagesNames;
            }
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenId, product.Id));

        }

        public async Task<bool> DeleteProductAsync(string Id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id.ToString() == Id);
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

        //Private methods
        private async Task<Product> TransformProduct(ProductDto productDto)
        {
            return new Product()
            {
                Name = productDto.Name,
                Category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == productDto.Category),
                Price = productDto.Price,
                Description = productDto.Description,
                QuantityInStock = productDto.QuantityInStock,
                ProductAmount = productDto.ProductAmount,
                MainImageName = productDto.MainImageFile.FileName
            };
        }
        private ProductDto TransformProduct(Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductAmount = product.ProductAmount,
                Category = product.Category.Name,
                MainImageName = product.MainImageName
            };
        }
    }
}
