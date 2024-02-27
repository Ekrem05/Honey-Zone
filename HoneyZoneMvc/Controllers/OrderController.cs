using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HoneyZoneMvc.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartProductService cartProductService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IDeliveryService deliveryService;

        public OrderController(ICartProductService _cartService,
            IProductService _productService,
            IOrderService _orderService,
            IDeliveryService deliveryService)
        {
            cartProductService = _cartService;
            productService = _productService;
            orderService = _orderService;
            this.deliveryService = deliveryService;

        }
        [HttpGet]
        public async Task<IActionResult> OrderDetails()
        {
            var orderDto = new OrderDetailDto();
            var cart=await cartProductService.GetCartByUserIdAsync(GetUserId().ToString());
            orderDto.TotalSum = await cartProductService.GetCartSumAsync(GetUserId().ToString());
            orderDto.DeliveryMethods = await GetDeliveryMethods();
            return View(orderDto);
        }
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var orders = await orderService.GetUserOrdersIdAsync(GetUserId().ToString());
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> OrderConfirmed(OrderDetailDto dto)
        {
            var cart = await cartProductService.GetCartByUserIdAsync(GetUserId().ToString());
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            
            foreach (var productItem in cart)
            {
                var product = await productService.GetProductByIdAsync(productItem.ProductId);

                orderProducts.Add(new OrderProduct()
                {
                    ProductId = Guid.Parse(productItem.ProductId),
                    Quantity = productItem.Quantity,
                });
              
            }
            await orderService.AddAsync(GetUserId().ToString(), dto.TotalSum, dto.DeliveryMethodId, dto, orderProducts);
            await cartProductService.DeleteCartProductAsync(GetUserId().ToString());
            return RedirectToAction("Index", "Shop");
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
