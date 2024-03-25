using HoneyZoneMvc.BusinessLogic.ViewModels.Statistics;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IStatisticService
    {
        Task<StatisticsViewModel> CategoryStatisticsAsync();
    }
}
