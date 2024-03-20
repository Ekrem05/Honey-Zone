using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly IStatisticService statisticService;

        public HomeController(IStatisticService _statisticService)
        {
           statisticService = _statisticService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                StatisticsViewModel stats = await statisticService.CategoryStatisticsAsync();
                return View(stats);
            }
            catch (Exception)
            {
               
            }
           return View();

        }
    }
}
