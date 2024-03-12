using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public double TotalSum { get; set; }

        [ForeignKey(nameof(DeliveryMethodId))]
        public Guid DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; } = null!;

        [Required]
        public string ClientId { get; set; } = string.Empty;
        public IdentityUser Client { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; }

        [AllowNull]
        public DateTime ExpectedDelivery { get; set; }

        [ForeignKey(nameof(StateId))]
        public Guid StateId { get; set; }
        public State State { get; set; } = null!;

        [ForeignKey(nameof(OrderDetailId))]
        public Guid OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; } = null!;

        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
