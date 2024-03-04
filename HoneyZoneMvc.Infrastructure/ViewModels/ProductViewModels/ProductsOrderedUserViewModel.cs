using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductsOrderedUserViewModel
    {
        public bool IsDiscounted { get; set; }
        public string DiscountedPrice { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string ProductAmount { get; set; }
    }
}
