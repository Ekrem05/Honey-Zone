using HoneyZoneMvc.Infrastructure.ViewModels.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HoneyZoneMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode==404)
            {
                return View("Error404");
            }
            else if (statusCode == 500)
            {
                return View("Error500");
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
