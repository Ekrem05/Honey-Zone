using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int TotalSum{ get; set; }

        [ForeignKey(nameof(DeliveryMethodId))]
        public int DeliveryMethodId { get; set; }
        [Required]
        public DeliveryMethod DeliveryMethod { get; set; }

        [Required]
        public string ClientId { get; set; }
        public IdentityUser Client { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public ICollection<OrderDetails> OrderDetails = new HashSet<OrderDetails>();
    }
}
