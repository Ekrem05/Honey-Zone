using HoneyZoneMvc.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class OrderProduct
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
