using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class CartProductDto
    {
        public Guid ProductId { get; set; }
        public Guid BuyerId { get; set; }
    }
}
