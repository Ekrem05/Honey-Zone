using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductShopCardViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }    
        public double Price { get; set; }
        public string MainImageName { get; set; }

    }
}
