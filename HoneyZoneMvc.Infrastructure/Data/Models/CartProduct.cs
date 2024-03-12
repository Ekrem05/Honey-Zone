using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class CartProduct
    {
        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey(nameof(ClientId))]
        public string ClientId { get; set; } = string.Empty;
        public IdentityUser Client { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }


    }
}