using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels.ProductViewModels;
using HoneyZoneMvc.Messages;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext dbContext;
        private ICategoryService categoryService;
        private IImageService imageService;
        public ProductService(ApplicationDbContext _dbContext, ICategoryService _categoryService, IImageService _imageService)
        {
            dbContext = _dbContext;
            categoryService = _categoryService;
            imageService = _imageService;
        }
        public async Task<bool> AddProductAsync(ProductAddViewModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.ArgumentNull, nameof(ProductDto)));
            }
            Product productToAdd = await TransformProduct(product);
            productToAdd.MainImageUrl = await GetUrl(product.MainImage);

            var imagesInDb = imageService.GetImages();
            foreach (var image in product.Images)
            {
                if (!imagesInDb.Any(i => i.Name == image.FileName))
                {
                    productToAdd.Images.Add(new ImageUrl() { Name = product.MainImage.FileName });
                    var imagePath = await GetUrl(product.Images);
                }
                else
                {
                    productToAdd.Images.Add(await imageService.GetImageByNameAsync(image.FileName));

                }
            }
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
                .FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            if (model != null)
            {
                return TransformProduct(model);
            }


            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenId, Id));
        }

        public async Task<ProductEditViewModel> GetProductEditByIdAsync(string Id)
        {
            var model = await dbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            if (model != null)
            {
                return GetProductEditViewModel(model);
            }


            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenId, Id));
        }


        public async Task<bool> UpdateProductAsync(ProductEditViewModel product)
        {
            var productToEdit = await dbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id.ToString() == product.Id.ToString());

            if (productToEdit != null)
            {
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                productToEdit.Description = product.Description;
                productToEdit.ProductAmount = product.ProductAmount;
                productToEdit.Category = dbContext.Categories.FirstOrDefault(c => c.Name == product.Category);
                productToEdit.QuantityInStock = product.QuantityInStock;
                if (product.MainImage != null)
                {
                    productToEdit.MainImageUrl = await GetUrl(product.MainImage);

                }
                if (product.Images != null)
                {
                    foreach (var image in product.Images)
                    {
                     var imagePath = await GetUrl(image);
                      productToEdit.Images.Add(new ImageUrl() { Name = image.FileName,ProductId=product.Id });
                         
                    }

                }
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
            var orders = dbContext.Orders.Where(o => o.OrderProducts.Any(op => op.ProductId == product.Id));
            if (orders!=null)
            {
                return false;
            }
            dbContext.ImageUrls.RemoveRange(dbContext.ImageUrls.Where(i => i.ProductId == product.Id));
            dbContext.OrderProducts.RemoveRange(dbContext.OrderProducts.Where(op => op.ProductId == product.Id));
            dbContext.Remove(product);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;

        }


        public async Task<IEnumerable<ProductCartViewModel>> GetUserCartAsync(string Id)
        {
            var carProducts = await dbContext.CartProducts
                .Include(cp => cp.Product)
                .AsNoTracking()
                .Where(cp => cp.ClientId == Id)
                .Select(cp => new ProductCartViewModel()
                {
                    Id = cp.Product.Id,
                    Name = cp.Product.Name,
                    MainImageName = cp.Product.MainImageUrl,
                    Price = cp.Product.Price,
                    ProductAmount = cp.Product.ProductAmount,
                    Quantity = 1
                })
                .ToListAsync();

            if (carProducts != null)
            {
                return carProducts;
            }
            else { throw new Exception(); }///HERE!!
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
                MainImageUrl = productDto.MainImageFile.FileName,
                Images=imageService.GetImages().Where(i=>i.ProductId==productDto.Id).ToList()
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
                MainImageName = product.MainImageUrl,
                Images = imageService.GetImages().Where(i => i.ProductId == product.Id).ToList()
            };
        }
        private async Task<Product> TransformProduct(ProductAddViewModel product)
        {
            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductAmount = product.ProductAmount,
                CategoryId = Guid.Parse(product.CategoryId),
            };
        }

        private ProductEditViewModel GetProductEditViewModel(Product product)
        {
            return new ProductEditViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductAmount = product.ProductAmount,
                Category = product.Category.Name
            };
        }

        private async Task<string> GetUrl(IFormFile mainImage)
        {
            string url = Path.Combine(Environment.CurrentDirectory, "wwwroot", "productImages");

            string filePath = Path.Combine(url, mainImage.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await mainImage.CopyToAsync(fileStream);
            }
            return mainImage.FileName;
        }
        private async Task<List<ImageUrl>> GetUrl(ICollection<IFormFile> images)
        {
            var imageEntities = imageService.GetImages();
            List<ImageUrl> imageUrls = new List<ImageUrl>();
            string url = Path.Combine(Environment.CurrentDirectory, "wwwroot", "productImages");


            foreach (var image in images.Where(i => imageEntities.Any(entity => entity.Name == i.FileName)))
            {
                string filePath = Path.Combine(url, image.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                imageUrls.Add(new ImageUrl() { Name = image.FileName });
            }

            return imageUrls;
        }

    }
}
