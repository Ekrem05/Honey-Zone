using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;

namespace HoneyZoneMvc.Controllers
{
    public class ProfileController:Controller
    {
        private readonly IOrderService orderService;

        public ProfileController(IOrderService _orderService)
        {
            orderService = _orderService;

        }
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            try
            {   
                var orders= await orderService.OrdersByUserIdAsync(GetUserId().ToString());               
                return View(orders);
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 500 });
            }
        }
        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
