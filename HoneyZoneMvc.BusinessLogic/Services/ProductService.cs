using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
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
                throw new ArgumentNullException(string.Format(ExceptionMessages.ArgumentNull, nameof(ProductAddViewModel)));
            }
            Product productToAdd = await TransformProduct(product);
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
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;

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
            throw new ArgumentNullException(string.Format(ExceptionMessages.NoProductsWithGivenCategory, category));

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
                    IsDiscounted=p.IsDiscounted,
                    Discount=p.Discount
                })
                .ToListAsync();
        }

        public async Task<ProductAdminViewModel> GetProductByIdAsync(string Id)
        {
            var model = await dbContext.Products
                .Include(p => p.Category)
                .Include(p=>p.Images)
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
                if (product.Discount>0)
                {
                    productToEdit.IsDiscounted = true;
                }
                productToEdit.Discount = product.Discount;
                productToEdit.Category = dbContext.Categories.FirstOrDefault(c => c.Name == product.Category);
                productToEdit.QuantityInStock = product.QuantityInStock;
                if (product.MainImage != null)
                {
                    productToEdit.MainImageUrl = await SaveLocally(product.MainImage);

                }
                if (product.Images != null)
                {
                    foreach (var image in product.Images)
                    {
                     var imagePath = await SaveLocally(image);
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
            var orders = await dbContext.Orders
                .Where(o=>o.State.Name
                !="Завършена")
                .Where(o => o.OrderProducts.Any(op => op.ProductId == product.Id)).ToListAsync();
            if (orders.Count()>0)
            {
                return false;
            }
            dbContext.ImageUrls.RemoveRange(dbContext.ImageUrls.Where(i => i.ProductId == product.Id));
            dbContext.CartProducts.RemoveRange(dbContext.CartProducts.Where(cp => cp.ProductId == product.Id));
            dbContext.Remove(product);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> SetDiscountAsync(ProductDiscountViewModel vm)
        {
            var product=dbContext.Products.FirstOrDefault(p => p.Id.ToString() == vm.Id);
            product.IsDiscounted= true;
            product.Discount = vm.Discount;
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SetDiscountByCategoryAsync(string Id, double discount)
        {
            var product=dbContext.Products.Where(p => p.CategoryId.ToString() == Id);
            foreach (var item in product)
            {
                item.IsDiscounted = true;
                item.Discount = discount;
            }
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveDiscountAsync(string Id)
        {
            var product=dbContext.Products.FirstOrDefault(p => p.Id.ToString() == Id);
            
                product.Discount = 0;
                product.IsDiscounted = false;
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
                    IsDiscounted=cp.Product.IsDiscounted,
                    Discount=cp.Product.Discount,
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
                product.QuantityInStock --;
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
                IsDiscounted=product.IsDiscounted,
                Discount=product.Discount,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductAmount = product.ProductAmount,
                Category = product.Category.Name,
                MainImageName = product.MainImageUrl,
                Images = product.Images.Select(i => i.Name).ToArray()
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
