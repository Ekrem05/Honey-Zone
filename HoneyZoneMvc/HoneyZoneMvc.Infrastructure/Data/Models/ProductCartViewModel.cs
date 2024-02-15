using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class ProductCartViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string MainImageName { get; set; }
        public string ProductAmount { get; set; }
        public int Quantity { get; set; }
    }
}
