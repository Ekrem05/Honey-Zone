using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Order
{
    public class OrderAddViewModel
    {
        public double TotalSum { get; set; }

        public string DeliveryMethodId { get; set; }

        public string ClientId { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public DateTime ExpectedDelivery { get; set; }
      
        public string StateId { get; set; }
       
        public string OrderDetailId { get; set; }

        public OrderDetailViewModel OrderDetail { get; set; } = null!;

        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
