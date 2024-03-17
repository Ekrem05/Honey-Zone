using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Common.Messages;
using HoneyZoneMvc.BusinessLogic.ViewModels.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HoneyZoneMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger,IProductService _productService)
        {
            _logger = logger;
            productService = _productService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var topThreeBestSellers = (await productService.GetBestSellersAsync()).Take(3);
                return View(topThreeBestSellers);
            }
            catch (Exception)
            {
                TempData["Message"]=ExceptionMessages.GeneralException;
                return RedirectToAction("Error", new { statusCode = 500 });
            }
            
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

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
