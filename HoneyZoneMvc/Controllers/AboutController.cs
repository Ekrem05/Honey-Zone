using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
