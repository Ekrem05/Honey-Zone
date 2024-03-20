using HoneyZoneMvc.BusinessLogic.ViewModels.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IStatisticService
    {
        Task<StatisticsViewModel> CategoryStatisticsAsync();
    }
}
