using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int TotalSum { get; set; }

        [ForeignKey(nameof(DeliveryMethodId))]
        public Guid DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }

        [Required]
        public string ClientId { get; set; }
        public IdentityUser Client { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [AllowNull]
        public DateTime ExpectedDelivery { get; set; }

        [ForeignKey(nameof(StateId))]
        public Guid StateId { get; set; }
        public State State { get; set; }

        [ForeignKey(nameof(OrderDetailId))]
        public Guid OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }

    }
}
