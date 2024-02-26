using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HoneyZoneMvc.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICartProductService cartProductService;
        private readonly IDeliveryService deliveryService;
        private readonly IOrderService orderService;
        private readonly IStateService stateService;


        public ShopController(IProductService _productService,
            ICategoryService _categoryService,
            ICartProductService _cartProductService,
            IDeliveryService _deliveryService,
            IOrderService _orderService,
            IStateService _stateService)
        {
            productService = _productService;
            categoryService = _categoryService;
            cartProductService = _cartProductService;
            deliveryService = _deliveryService;
            orderService = _orderService;
            stateService = _stateService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? category)
        {
            AdminViewModel vm = new AdminViewModel();
            vm.Products = await productService.GetAllProductsAsync();
            vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
            if (category != null)
            {
                var productsCategorized = await productService.GetProductsByCategoryAsync(category);
                vm.Products = productsCategorized;
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
        public async Task<IActionResult> Cart()
        {
            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());
            return View(productsInCart);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddToCart(string Id)
        {
            bool successfull = await cartProductService.AddCartProductAsync(new CartProductDto()
            {
                BuyerId = GetUserId().ToString(),
                ProductId = Id
            });

            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());

            return RedirectToAction("Cart", productsInCart);
        }
        [HttpPost]
        public async Task<IActionResult> CartConfirmed(List<PostProductCart> cartProducts)
        {
            foreach (var cartProduct in cartProducts)
            {
                await cartProductService.UpdateQuantityAsync(cartProduct.Id, cartProduct.Quantity, GetUserId().ToString());
            }

            return RedirectToAction("OrderDetails", "Order");
        }



        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
