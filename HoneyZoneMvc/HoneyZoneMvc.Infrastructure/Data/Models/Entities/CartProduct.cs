using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyZoneMvc.Models.Entities
{
    public class CartProduct
    {
        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        public IdentityUser Client { get; set; }

        [Required]
        public int Quantity { get; set; }


    }
}