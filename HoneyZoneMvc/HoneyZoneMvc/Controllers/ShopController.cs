using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using HoneyZoneMvc.Models.Entities;
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
           
            return RedirectToAction("Cart",productsInCart);
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
            orderDto.DeliveryMethods = await GetDeliveryMethods();
            return View(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> OrderConfirmed(OrderDetailDto dto)
        {
            var cart = await cartProductService.GetCartByUserIdAsync(GetUserId().ToString());
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            double totalSum = 0;
            foreach (var productItem in cart)
            {
                var product = await productService.GetProductByIdAsync(productItem.ProductId);

                orderProducts.Add(new OrderProduct()
                {
                    ProductId = Guid.Parse(productItem.ProductId),
                    Quantity = productItem.Quantity,
                });
                totalSum += product.Price;
            }
            await orderService.AddAsync(GetUserId().ToString(), totalSum, dto.DeliveryMethodId, dto, orderProducts);
            await cartProductService.DeleteCartProductAsync(GetUserId().ToString());
            return RedirectToAction(nameof(Index));
        }

        private async Task<ICollection<DeliveryMethodDto>> GetDeliveryMethods()
        {
            return await deliveryService.GetAllAsync();
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
