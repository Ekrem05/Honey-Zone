using HoneyZoneMvc.Models.Entities;
using HoneyZoneMvc.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Models.ViewModels
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1.00,10000)]
        public double Price { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, 10000)]
        public int QuantityInStock { get; set; }

        [Required]
        [RegularExpression("^\\d+\\s?(ml|l|g|mg|kg)$", ErrorMessage = "Has to start with a number and end with (ml;l;g;mg;kg)")]
        public string ProductQuantity { get; set; }

        public string MainImageName { get; set; }

        public IFormFile MainImageFile{ get; set; }

        public ICollection<string> ImagesNames { get; set; }

    }
}
