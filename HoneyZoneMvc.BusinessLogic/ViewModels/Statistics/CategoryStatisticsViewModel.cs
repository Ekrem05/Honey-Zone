using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyZoneMvc.BusinessLogic.Contracts.ExtensionContracts;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Statistics
{
    public class CategoryStatisticsViewModel:ICategoryStatistic
    {
        public string[] Categories { get; set; }
        public Dictionary<string, int> ProductsSoldInCategory { get; set; }
    }
}
