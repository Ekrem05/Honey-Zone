using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            //Show Orders today, Show Profit today, Show Total Orders, Show Total Profit
            return View();
        }
    }
}
