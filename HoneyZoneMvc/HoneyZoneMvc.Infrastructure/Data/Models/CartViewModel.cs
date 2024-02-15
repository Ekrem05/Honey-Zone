using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class CartViewModel
    { 
        
        public string ClientId { get; set; }
        public double Sum { get; set; }
        public ICollection<ProductCartViewModel> Products = new List<ProductCartViewModel>();
    }
}
