using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Statistics
{
    public class StatisticsViewModel
    {
        public CategoryStatisticsViewModel CategoryStatistic { get; set; } = new CategoryStatisticsViewModel();
    }
}
