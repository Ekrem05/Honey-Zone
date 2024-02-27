using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels.ProductViewModels
{
    public class ProductOrdered
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string ProductAmount { get; set; }   

    }
}
