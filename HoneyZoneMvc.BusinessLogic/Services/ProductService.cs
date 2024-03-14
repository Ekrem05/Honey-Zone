﻿using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.BusinessLogic.ViewModels.ProductViewModels;
using HoneyZoneMvc.Common.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static System.Net.Mime.MediaTypeNames;
using HoneyZoneMvc.Infrastructure.Data.Models;
using AutoMapper;
namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext dbContext;
        private ICategoryService categoryService;
        private IImageService imageService;
        private IMapper mapper;
        public ProductService(ApplicationDbContext _dbContext, ICategoryService _categoryService, IImageService _imageService,IMapper _mapper)
        {
            dbContext = _dbContext;
            categoryService = _categoryService;
           imageService = _imageService;
            mapper = _mapper;
        }
        public async Task AddProductAsync(ProductAddViewModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ValidationMessages.ArgumentNull, nameof(ProductAddViewModel)));
            }
            Product productToAdd = mapper.Map<Product>(product);

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
                productsDto.Add(mapper.Map<ProductAdminViewModel>(product));
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
                    productsDto.Add(mapper.Map<ProductAdminViewModel>(product));
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
                 .Select(p => mapper.Map<ProductAdminViewModel>(p))
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
                var item =mapper.Map<ProductAdminViewModel>(model);
                return item;
            }


            throw new ArgumentNullException(string.Format(ProductMessages.NoProductsWithGivenId, Id));
        }

        public async Task<IEnumerable<ProductShopCardViewModel>> GetBestSellersAsync()
        {
            return await dbContext.Products.OrderByDescending(p => p.TimesOrdered).Select(dbContext => new ProductShopCardViewModel()
            {
                Id = dbContext.Id.ToString(),
                Name = dbContext.Name,
                Price = dbContext.Price,
                MainImageName = dbContext.MainImageUrl,
                IsDiscounted = dbContext.IsDiscounted,
                Discount = dbContext.Discount
            }).ToListAsync();
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


        public async Task DecreaseProductQuantityAsync(string Id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id.ToString() == Id);
            if (product != null)
            {
                product.QuantityInStock--;
                await dbContext.SaveChangesAsync();

            }
        }
        public async Task IncreaseTotalOrdersAsync(string Id, int quantity)
        {
            if (Id==null)
            {
                throw new ArgumentNullException(IdNull);
            }
            var product = dbContext.Products.FirstOrDefault(p => p.Id.ToString() == Id);
            if (product==null)
            {
                throw new ArgumentNullException(string.Format(ProductMessages.NoProductsWithGivenId, Id));
            }
            product.TimesOrdered += quantity;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductAdminViewModel>> SearchProductsAsync(string searchBy)
        {
            return await dbContext.Products
                .Where(p => p.Name.Contains(searchBy))
                .Select(p => mapper.Map<ProductAdminViewModel>(p))
                .ToListAsync();
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
