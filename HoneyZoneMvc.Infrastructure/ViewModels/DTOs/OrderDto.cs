using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HoneyZoneMvc.Infrastructure.ViewModels.DTOs
{
    public class OrderDto
    {
        [Required]
        public double TotalSum { get; set; }

        [Required]
        public Guid DeliveryMethodId { get; set; }

        [Required]
        public string ClientId { get; set; }

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
