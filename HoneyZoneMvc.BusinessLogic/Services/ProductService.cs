using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using HoneyZoneMvc.Common.Messages;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static System.Net.Mime.MediaTypeNames;
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
        public async Task AddProductAsync(ProductAddViewModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ValidationMessages.ArgumentNull, nameof(ProductAddViewModel)));
            }
            Product productToAdd = TransformProduct(product);

            productToAdd.MainImageUrl = await SaveLocally(product.MainImage);

            productToAdd.Images.Add(new ImageUrl() { Name = productToAdd.MainImageUrl });

            var imagesInDb = imageService.GetImages();

            foreach (var image in product.Images)
            {

                if (!imagesInDb.Any(i => i.Name == image.FileName))
                {
                    var imagePath = await SaveLocally(image);
                    productToAdd.Images.Add(new ImageUrl() { Name = imagePath });
                }
                else
                {
                    productToAdd.Images.Add(await imageService.GetImageByNameAsync(image.FileName));

                }
            }
            await dbContext.Products.AddAsync(productToAdd);
            await dbContext.SaveChangesAsync();
           

        }

        public async Task<IEnumerable<ProductAdminViewModel>> GetAllProductsAsync()
        {
            var models = await dbContext.Products
                .Include(p => p.Category)
                .ToListAsync();

            List<ProductAdminViewModel> productsDto = new List<ProductAdminViewModel>();

            foreach (var product in models)
            {
                productsDto.Add(TransformProduct(product));
            }
            return productsDto;
        }

        public async Task<IEnumerable<ProductAdminViewModel>> GetProductsByCategoryNameAsync(string category)
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
                List<ProductAdminViewModel> productsDto = new List<ProductAdminViewModel>();
                foreach (var product in models)
                {
                    productsDto.Add(TransformProduct(product));
                }
                return productsDto;
            }
            throw new ArgumentNullException(string.Format(ProductMessages.NoProductsWithGivenCategory, category));

        }

        public async Task<IEnumerable<ProductAdminViewModel>> GetProductsByCategoryIdAsync(string Id)
        {
            return await dbContext.Products
                 .Include(p => p.Category)
                 .Where(p => p.CategoryId.ToString() == Id)
                 .Select(p => new ProductAdminViewModel()
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Price = p.Price,
                     Description = p.Description,
                     QuantityInStock = p.QuantityInStock,
                     ProductAmount = p.ProductAmount,
                     Category = p.Category.Name,
                     MainImageName = p.MainImageUrl,
                     IsDiscounted = p.IsDiscounted,
                     Discount = p.Discount
                 })
                 .ToListAsync();
        }

        public async Task<ProductAdminViewModel> GetProductByIdAsync(string Id)
        {
            var model = await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            if (model != null)
            {
                return TransformProduct(model);
            }


            throw new ArgumentNullException(string.Format(ProductMessages.NoProductsWithGivenId, Id));
        }

        public async Task<ProductEditViewModel> GetProductEditByIdAsync(string Id)
        {
            var model = await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            if (model != null)
            {
                return GetProductEditViewModel(model);
            }


            throw new ArgumentNullException(string.Format(ProductMessages.NoProductsWithGivenId, Id));
        }

        public async Task UpdateProductAsync(ProductEditViewModel product)
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
                if (product.Discount > 0)
                {
                    productToEdit.IsDiscounted = true;
                }
                productToEdit.Discount = product.Discount;
                productToEdit.CategoryId = dbContext.Categories.FirstOrDefault(c => c.Id.ToString() == product.CategoryId).Id;
                productToEdit.QuantityInStock = product.QuantityInStock;
                if (product.MainImage != null)
                {
                    productToEdit.MainImageUrl = await SaveLocally(product.MainImage);

                }
                if (product.Images != null)
                {
                    productToEdit.Images.Add(new ImageUrl() { Name = productToEdit.MainImageUrl, ProductId = product.Id });
                    foreach (var image in product.Images)
                    {
                        var imagePath = await SaveLocally(image);
                        productToEdit.Images.Add(new ImageUrl() { Name = image.FileName, ProductId = product.Id });

                    }

                }
            }
            dbContext.SaveChanges();
            
        }

        public async Task DeleteProductAsync(string Id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id.ToString() == Id);
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ProductMessages.NoProductsWithGivenId, Id));
            }
            var orders = await dbContext.Orders
                .Where(o => o.State.Name
                != "Завършена")
                .Where(o => o.OrderProducts.Any(op => op.ProductId == product.Id)).ToListAsync();
            if (orders.Count() > 0)
            {
                throw new InvalidOperationException(ProductMessages.ProductCannotBeDeleted);
            }
            dbContext.ImageUrls.RemoveRange(dbContext.ImageUrls.Where(i => i.ProductId == product.Id));
            dbContext.CartProducts.RemoveRange(dbContext.CartProducts.Where(cp => cp.ProductId == product.Id));
            dbContext.Remove(product);
            await dbContext.SaveChangesAsync();
           
        }

        public async Task SetDiscountAsync(ProductDiscountViewModel vm)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id.ToString() == vm.Id);
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            product.IsDiscounted = true;
            product.Discount = vm.Discount;
            await dbContext.SaveChangesAsync();
        
        }

        public async Task SetDiscountByCategoryAsync(string Id, double discount)
        {
            if (Id==null)
            {
                throw new ArgumentNullException();
            }
            var product = dbContext.Products.Where(p => p.CategoryId.ToString() == Id);
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var item in product)
            {
                item.IsDiscounted = true;
                item.Discount = discount;
            }
            await dbContext.SaveChangesAsync();
           
        }

        public async Task RemoveDiscountAsync(string Id)
        {
            if (Id==null)
            {
                throw new ArgumentNullException();

            }
            var product = dbContext.Products.FirstOrDefault(p => p.Id.ToString() == Id);
            if (product==null)
            {
                throw new ArgumentNullException();
            }
            product.Discount = 0;
            product.IsDiscounted = false;
            await dbContext.SaveChangesAsync();
           
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
                    IsDiscounted = cp.Product.IsDiscounted,
                    Discount = cp.Product.Discount,
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

        public async Task DecreaseProductQuantityAsync(string Id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id.ToString() == Id);
            if (product != null)
            {
                product.QuantityInStock--;
                await dbContext.SaveChangesAsync();

            }
        }






        //Private methods
        private ProductAdminViewModel TransformProduct(Product product)
        {
            return new ProductAdminViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                IsDiscounted = product.IsDiscounted,
                Discount = product.Discount,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductAmount = product.ProductAmount,
                Category = product.Category.Name,
                MainImageName = product.MainImageUrl,
                Images = product.Images.Select(i => i.Name).ToArray()
            };
        }
        private Product TransformProduct(ProductAddViewModel product)
        {
            return new Product()
            {
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
                Discount = product.Discount,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductAmount = product.ProductAmount,
                CategoryId = product.Category.Name
            };
        }

        private async Task<string> SaveLocally(IFormFile mainImage)
        {
            string url = Path.Combine(Environment.CurrentDirectory, "wwwroot", "productImages");

            string filePath = Path.Combine(url, mainImage.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await mainImage.CopyToAsync(fileStream);
            }
            return mainImage.FileName;
        }

    }
}
