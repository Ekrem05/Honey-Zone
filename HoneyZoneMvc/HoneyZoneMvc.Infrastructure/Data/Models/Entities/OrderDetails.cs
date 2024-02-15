using HoneyZoneMvc.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(ProducId))]
        public string ProducId { get; set; }
        public Product Product { get; set; }


        [Required]
        public int Quantity { get; set; }

    }
}