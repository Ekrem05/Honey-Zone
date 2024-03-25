using HoneyZoneMvc.BusinessLogic.Contracts.ExtensionContracts;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Statistics
{
    public class CategoryStatisticsViewModel : ICategoryStatistic
    {
        public string[] Categories { get; set; }
        public Dictionary<string, int> ProductsSoldInCategory { get; set; }
    }
}
