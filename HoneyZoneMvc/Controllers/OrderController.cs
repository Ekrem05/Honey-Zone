using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.ViewModels.Delivery;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;

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
        public async Task<IActionResult> MyOrders()
        {
            try
            {
                var orders = await orderService.GetUserOrdersIdAsync(GetUserId().ToString());
                return View(orders);
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
          
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetails()
        {
            try
            {
                var ordervm = new OrderDetailViewModel();
                var cart = await cartProductService.GetCartByUserIdAsync(GetUserId().ToString());
                ordervm.TotalSum = (await cartProductService.GetCartSumAsync(GetUserId().ToString())).ToString("F2");
                ordervm.DeliveryMethods = await GetDeliveryMethods();
                return View(ordervm);
            }
            catch (Exception)
            {

                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
         
        }
        [HttpPost]
        public async Task<IActionResult> OrderConfirmed(OrderDetailViewModel dto)
        {

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid input";
                return RedirectToAction(nameof(OrderDetails));
            }
            try
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
                await orderService.AddAsync(GetUserId().ToString(), totalSum, dto.DeliveryMethodId, dto, orderProducts);
                await cartProductService.DeleteCartProductAsync(GetUserId().ToString());
            }
            catch (InvalidOperationException e)
            {
                TempData["Error"] = "Your cart is empty";
                return RedirectToAction(nameof(OrderDetails));
            }
            catch (Exception e)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
            TempData["Message"] = OrderAdded;
            return RedirectToAction("MyOrders");
        }
        [HttpGet]
        [ActionName("OrderInformation")]
        public async Task<IActionResult> OrderInformation(string Id)
        {
            try
            {
                var orderInfo = await orderService.GetOrderDetailsAsync(Id);
                return View(orderInfo);
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home",new { statusCode = 404 });
            }
        }
        [HttpGet]
        [ActionName("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(string Id)
        {
            try
            {
                var order = await orderService.GetOrderByIdAsync(Id);
                return View(order);
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
        }
        [HttpPost]
        [ActionName("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(ChangeOrderStatusViewModel vm)
        {
            try
            {
                await orderService.ChangeStatusAsync(vm);
                TempData["Success"] = OrderStatusChanged;
                return RedirectToAction("Index", "AdminData");
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
          
        }

        [HttpPost]
        [ActionName("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(string Id)
        {
            var order = await orderService.GetOrderByIdAsync(Id);

            if (Id != null && order != null)
            {
                await orderService.DeleteOrderAsync(Id);
                TempData["Success"]= OrderDeleted;
                return RedirectToAction("Index", "AdminData");
            }
            TempData["Error"] = GeneralException;
            return RedirectToAction("Error", "Home", new { statusCode = 404 });
        }

        private async Task<ICollection<DeliveryMethodViewModel>> GetDeliveryMethods()
        {
            try
            {
                return await deliveryService.GetAllAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
          
        }
        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

    }
}
