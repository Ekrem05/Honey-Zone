using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Show Orders today, Show Profit today, Show Total Orders, Show Total Profit
            return View();
        }
    }
}
