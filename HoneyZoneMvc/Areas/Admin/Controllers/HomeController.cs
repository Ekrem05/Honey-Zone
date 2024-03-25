using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Errors;
using HoneyZoneMvc.BusinessLogic.ViewModels.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
                StatisticsViewModel stats = new StatisticsViewModel();
                stats.CategoryStatistic=await statisticService.CategoryStatisticsAsync();
                stats.StockStatistic=await statisticService.StockStatisticsAsync();
                return View(stats);
            }
            catch (Exception e)
            {
                RedirectToAction("Error", new { e });
            }
            return View();

        }
        public IActionResult Error(Exception e)
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = e.Message,
                StackTrace = e.StackTrace,
                Source = e.Source
            });
        }
    }
}
