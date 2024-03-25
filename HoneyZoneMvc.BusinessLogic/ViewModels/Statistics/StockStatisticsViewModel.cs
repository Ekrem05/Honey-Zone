using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Statistics
{
    public class StockStatisticsViewModel
    {   
        public Dictionary<string,int> ProductsInStockPair { get; set; }
    }
}
