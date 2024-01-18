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
        public IActionResult Index()
        {
            var products = productService.GetAllProducts();
            ProductDto productsDto = new ProductDto();
            productsDto.Products = products.ToList();
            return View(productsDto);
        }
    }
}
