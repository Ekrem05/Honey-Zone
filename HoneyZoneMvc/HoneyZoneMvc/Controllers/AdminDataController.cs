using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Controllers
{
    public class AdminDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
