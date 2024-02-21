using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class OrderViewDto
    {
        public string Id { get; set; }

        public string TotalSum { get; set; }
        
        public string DeliveryMethod { get; set; }

        public string ClientName { get; set; }

        public string OrderDate { get; set; }

        public string ExpectedDelivery { get; set; }

        public string State { get; set; }
    }
}
