using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Services;
using Microsoft.AspNetCore.Mvc;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Order()
        {
            var orderDto = new OrderDetailDto();
            orderDto.DeliveryMethods = await GetDeliveryMethods();
            return View(orderDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
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
