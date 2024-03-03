using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<ProductShopCardViewModel> Products { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
