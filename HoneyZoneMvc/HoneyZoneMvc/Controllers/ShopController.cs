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
        public async Task<IActionResult> Index(string? category)
        {
            if (category != null)
            {
                var productsCategorized = await productService.GetProductsByCategoryAsync(category);
                return View(productsCategorized);
            }
            var productsDto = await productService.GetAllProductsAsync();
            return View(productsDto);
        }

        [HttpGet]
        public async Task<IActionResult> ViewProduct(int Id)
        {
            var productDto = await productService.GetProductByIdAsync(Id);

            return View(productDto);
        }

    }
}
