
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HoneyZoneMvc.Constraints.ValidationValues;

namespace HoneyZoneMvc.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(ProductNameMaxValue)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
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
        public string ProductQuantity { get; set; }

        [Required]
        public string MainImageName { get; set; }

        [Required]
        public ICollection<ImageName> ImageNames { get; set; }
    }
}
