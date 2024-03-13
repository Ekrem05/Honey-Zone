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
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;

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

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
