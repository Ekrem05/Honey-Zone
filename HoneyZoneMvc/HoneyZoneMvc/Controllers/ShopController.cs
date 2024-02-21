using HoneyZoneMvc.BusinessLogic.Contracts;
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
        private readonly ICartProductService cartProductService;


        public ShopController(IProductService _productService, ICategoryService _categoryService,ICartProductService _cartProductService)
        {
            productService = _productService;
            categoryService = _categoryService;
            cartProductService = _cartProductService;
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
            bool successfull = await cartProductService.AddCartProductAsync(new CartProductDto()
            {
                BuyerId = GetUserId(),
                ProductId = Guid.Parse(Id)
            });

            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());
           
            return View(productsInCart);
        }
        [HttpPost]
        public async Task<IActionResult> CartConfirmed(List<PostProductCart> cartProducts)
        {
            foreach (var cartProduct in cartProducts)
            {
                await cartProductService.UpdateQuantityAsync(cartProduct.Id, cartProduct.Quantity, GetUserId().ToString());
            }

            return RedirectToAction("Order");
        }
        [HttpGet]
        public async Task<IActionResult> Order()
        {
            var orderDto = new OrderDetailDto();
            orderDto.DeliveryMethods = GetDeliveryMethods();
            return View();
        }

        private ICollection<DeliveryMethodDto> GetDeliveryMethods()
        {
            throw new NotImplementedException();
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
