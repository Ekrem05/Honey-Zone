using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HoneyZoneMvc.Controllers
{
    public class ProfileController : Controller
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
                var orders = await orderService.OrdersByUserIdAsync(GetUserId().ToString());
                return View(orders);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
        }
        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
