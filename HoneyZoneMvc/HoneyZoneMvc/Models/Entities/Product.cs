using HoneyZoneMvc.Models.Entities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Category Category {  get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public int ProductQuantity { get; set; }
    }
}
