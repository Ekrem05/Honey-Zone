using AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Enums;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext dbContext;
        private ICategoryService categoryService;
        private IImageService imageService;
        private IMapper mapper;
        private IFileStorageService fileStorageService;
        public ProductService(ApplicationDbContext _dbContext,
            ICategoryService _categoryService,
            IImageService _imageService,
            IMapper _mapper,
            IFileStorageService _fileStorageService)
        {
            dbContext = _dbContext;
            categoryService = _categoryService;
            imageService = _imageService;
            mapper = _mapper;
            fileStorageService = _fileStorageService;
        }

        public async Task AddAsync(ProductAddViewModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(ProductMessages.ProductNotFound);
            }
            Product productToAdd = mapper.Map<Product>(product);

            productToAdd.MainImageUrl = await SaveLocally(product.MainImage);

            productToAdd.Images.Add(new ImageUrl() { Name = productToAdd.MainImageUrl });

            var imagesInDb = imageService.All();

            foreach (var image in product.Images)
            {

                if (!imagesInDb.Any(i => i.Name == image.FileName))
                {
                    var imagePath = await SaveLocally(image);
                    productToAdd.Images.Add(new ImageUrl() { Name = imagePath });
                }
                else
                {
                    productToAdd.Images.Add(await imageService.ImageByNameAsync(image.FileName));
                }
            }
            await dbContext.Products.AddAsync(productToAdd);
            await dbContext.SaveChangesAsync();


        }

        public async Task<IEnumerable<ProductAdminViewModel>> AllAsync()
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

        public async Task<AllProductsQueryModel> AllAsync(string? category = null,
            string? searchTerm = null,
            ProductSorting sorting = ProductSorting.Name,
            int currentPage = 1,
            int productsPerPage = 1)
        {
            var products = await AllAsync();

            if (!string.IsNullOrWhiteSpace(category))
            {
                products = await (GetByCategoryNameAsync(category));
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                products = products
                    .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            products = sorting switch
            {
                ProductSorting.Name => products.OrderBy(p => p.Name).ToList(),
                ProductSorting.Price => products.OrderBy(p => p.Price).ToList(),
                ProductSorting.TimesOrdered => products.OrderByDescending(p => p.TimesOrdered).ToList(),
                _ => products
                .OrderBy(p => p.Name).ToList()
            };
            var productsToShow = products
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToList();

            return new AllProductsQueryModel
            {
                Categories = (await categoryService.AllAsync()).Select(c => c.Name).ToList(),
                Products = productsToShow,
                TotalProductsCount = products.Count()
            };


        }

        public async Task<IEnumerable<ProductAdminViewModel>> GetByCategoryNameAsync(string category)
        {
            if (category==null)
            {
                throw new ArgumentNullException();
            }
            if (category.ToUpper() == "ALL")
            {
                return await AllAsync();
            }

            var models = await dbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name == category)
                .ToListAsync();

           
                List<ProductAdminViewModel> productsDto = new List<ProductAdminViewModel>();
                foreach (var product in models)
                {
                    productsDto.Add(mapper.Map<ProductAdminViewModel>(product));
                }
                return productsDto;
            

        }

        public async Task<IEnumerable<ProductAdminViewModel>> GetByCategoryIdAsync(string Id)
        {
            return await dbContext.Products
                 .Include(p => p.Category)
                 .Where(p => p.CategoryId.ToString() == Id)
                 .Select(p => mapper.Map<ProductAdminViewModel>(p))
                 .ToListAsync();
        }

        public async Task<ProductAdminViewModel> GetByIdAsync(string Id)
        {
            if (Id==null)
            {
                throw new ArgumentNullException();
            }
            var model = await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            
            var item = mapper.Map<ProductAdminViewModel>(model);
            return item;
            
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

        public async Task UpdateAsync(ProductEditViewModel product)
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
                productToEdit.CategoryId = dbContext.Categories.FirstOrDefault(c => c.Id.ToString() == product.CategoryId).Id;
                productToEdit.QuantityInStock = product.QuantityInStock;
            }
            dbContext.SaveChanges();

        }

        public async Task DeleteAsync(string Id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id.ToString() == Id);
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ProductMessages.NoProductWithGivenId, Id));
            }
            var orders = await dbContext.Orders
                .Where(o => o.State.Name
                != "Delivered")
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
                throw new ArgumentNullException(string.Format(ProductMessages.NoProductWithGivenId, vm.Id));
            }
            product.IsDiscounted = true;
            product.Discount = vm.Discount;
            await dbContext.SaveChangesAsync();

        }

        public async Task SetDiscountByCategoryAsync(string Id, double discount)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(ProductMessages.ProductNotFound);
            }
            var product = dbContext.Products.Where(p => p.CategoryId.ToString() == Id);
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ProductMessages.NoProductWithGivenId, Id));
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
            if (Id == null)
            {
                throw new ArgumentNullException(IdNull);
            }
            var product = dbContext.Products.FirstOrDefault(p => p.Id.ToString() == Id);
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ProductMessages.NoProductWithGivenId, Id));
            }
            product.Discount = 0;
            product.IsDiscounted = false;
            await dbContext.SaveChangesAsync();

        }


        public async Task DecreaseQuantityAsync(string Id)
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
            if (Id == null)
            {
                throw new ArgumentNullException(IdNull);
            }
            var product = dbContext.Products.FirstOrDefault(p => p.Id.ToString() == Id);
            if (product == null)
            {
                throw new ArgumentNullException(string.Format(ProductMessages.NoProductWithGivenId, Id));
            }
            product.TimesOrdered += quantity;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductAdminViewModel>> SearchAsync(string searchBy)
        {
            return await dbContext.Products
                .Where(p => p.Name.ToLower().Contains(searchBy.ToLower()))
                .Select(p => mapper.Map<ProductAdminViewModel>(p))
                .ToListAsync();
        }


        private async Task<string> SaveLocally(IFormFile mainImage)
        {
            string url = Path.Combine(Environment.CurrentDirectory, "wwwroot", "productImages");
            await fileStorageService.SaveFileAsync(mainImage, url);
            return mainImage.FileName;
        }

    }
}
