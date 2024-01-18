using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Models.ViewModels;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using HoneyZoneMvc.Models.Entities.Enums;

namespace HoneyZoneMvc.Controllers
{
    public class AdminDataController : Controller
    {
        private readonly IProductService productService;
        public AdminDataController(IProductService _productService)
        {
                productService = _productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products=productService.GetAllProducts();
            ProductDto productsDto = new ProductDto();
            productsDto.Products = products.ToList();
            return View(productsDto);
        }

        [HttpPost]
        public IActionResult Add(ProductDto product)
        {
            if (productService.AddProduct(new Product()
            {
                Name = product.Name,
                Category = Enum.Parse<Category>(product.Category),
                Price = product.Price,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductQuantity = product.ProductQuantity,
            }))
            {
                return RedirectToAction("index");
            }
           return RedirectToAction("index");

        }
    }
}
