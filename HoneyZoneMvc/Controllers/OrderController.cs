using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;
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
            var ordervm = new OrderDetailViewModel();
            var cart=await cartProductService.GetCartByUserIdAsync(GetUserId().ToString());
            ordervm.TotalSum = (await cartProductService.GetCartSumAsync(GetUserId().ToString())).ToString("F2");
            ordervm.DeliveryMethods = await GetDeliveryMethods();
            return View(ordervm);
        }
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var orders = await orderService.GetUserOrdersIdAsync(GetUserId().ToString());
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> OrderConfirmed(OrderDetailViewModel dto)
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
            var totalSumFormated = (await cartProductService.GetCartSumAsync(GetUserId().ToString())).ToString("F2");
            double totalSum = double.Parse(totalSumFormated);
            await orderService.AddAsync(GetUserId().ToString(),totalSum, dto.DeliveryMethodId, dto, orderProducts);
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
