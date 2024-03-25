namespace HoneyZoneMvc.BusinessLogic.ViewModels.Statistics
{
    public class StatisticsViewModel
    {
        public CategoryStatisticsViewModel CategoryStatistic { get; set; } = new CategoryStatisticsViewModel();
        public StockStatisticsViewModel StockStatistic { get; set; } = new StockStatisticsViewModel();
    }
}
