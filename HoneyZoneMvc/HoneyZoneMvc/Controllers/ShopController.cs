using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [HttpGet]
        public async Task<IActionResult> Cart(string Id)
        {
            bool successfull = await productService.AddCartProductAsync(new CartProductDto()
            {
                BuyerId = GetUserId(),
                ProductId = Guid.Parse(Id)
            });
            
            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());
            CartViewModel viewModel = new CartViewModel()
            {
                ClientId = GetUserId().ToString(),
                Products = productsInCart.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Order(List<PostProductCart> products)
        {
            return View();
        }
        private Guid GetUserId()
        {
           return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
