using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Controllers
{
    /// <summary>
    /// This controller is responsible for handling the home page of the application.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService _productService)
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
                return StatusCode(500);
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }

            return View("Error500");

        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
