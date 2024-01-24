using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService productService;
        public ShopController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public IActionResult Index(string? category)
        {
            if (category != null)
            {
                var productsCategorized = productService.GetProductsByCategory(category);
                List<ProductDto> productsCategorizedDto = new List<ProductDto>();
                foreach (var product in productsCategorized)
                {
                    productsCategorizedDto.Add(new ProductDto()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description,
                        QuantityInStock = product.QuantityInStock,
                        ProductQuantity = product.ProductQuantity,
                        Category = product.Category.ToString(),
                        MainImageName = product.MainImageName
                    });
                }
                return View(productsCategorizedDto);
            }
            var products = productService.GetAllProducts();
            List<ProductDto> productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDto.Add(new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    QuantityInStock = product.QuantityInStock,
                    ProductQuantity = product.ProductQuantity,
                    Category = product.Category.ToString(),
                    MainImageName = product.MainImageName
                });
            }
            return View(productsDto);
        }

        [HttpGet]
        public IActionResult ViewProduct(int Id)
        {
            var product = productService.GetProductById(Id);
            var ProductDto = new ProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductQuantity = product.ProductQuantity,
                Category = product.Category.ToString(),
                MainImageName = product.MainImageName
            };

            return View(ProductDto);
        }

    }
}
