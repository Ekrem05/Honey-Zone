using HoneyZoneMvc.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class OrderDetails
    {
        [ForeignKey(nameof(ProducId))]
        public string ProducId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(OrderId))]
        public string OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}