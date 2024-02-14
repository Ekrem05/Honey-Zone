using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ShopController(IProductService _productService, ICategoryService _categoryService)
        {
            productService = _productService;
            categoryService = _categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? category)
        {
            ProductViewModel vm = new ProductViewModel();
            vm.ProductDtos = await productService.GetAllProductsAsync();
            vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
            if (category != null)
            {
                var productsCategorized = await productService.GetProductsByCategoryAsync(category);
                vm.ProductDtos = productsCategorized;
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ViewProduct(string Id)
        {
            var productDto = await productService.GetProductByIdAsync(Id);

            return View(productDto);
        }

    }
}
