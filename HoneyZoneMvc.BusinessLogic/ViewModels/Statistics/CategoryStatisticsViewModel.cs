using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Statistics
{
    public class CategoryStatisticsViewModel
    {
        public string[] Categories { get; set; }
        public Dictionary<string, int> ProductsSoldInCategory { get; set; }
    }
}
