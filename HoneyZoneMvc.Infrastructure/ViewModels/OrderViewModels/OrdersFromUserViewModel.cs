using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels
{
    public class OrdersFromUserViewModel
    {
        public string TotalSum { get; set; }
        public string DeliveryMethod { get; set; }
        public string OrderDate { get; set; }
        public string ExpectedDelivery { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public List<ProductsOrderedUserViewModel> Products { get; set; } = new List<ProductsOrderedUserViewModel>();
    }
}
