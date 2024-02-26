
using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HoneyZoneMvc.Models.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Product.NameMaxValue)]
        [Comment("Product Name")]
        public string Name { get; set; }


        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category Identifier")]
        public Guid CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [Comment("Product Price")]
        public double Price { get; set; }

        [Required]
        [MaxLength(DataConstants.Product.DescriptionMaxValue)]
        [Comment("Product Description")]
        public string Description { get; set; }

        [Required]
        [Comment("Quantity Of The Product Available In Stock")]
        public int QuantityInStock { get; set; }

        [Required]
        [Comment("Product Amount")]
        public string ProductAmount { get; set; }

        [Required]
        public string MainImageUrl { get; set; }


        public ICollection<ImageUrl> Images = new List<ImageUrl>();


        public ICollection<CartProduct> CartProducts { get; set; } = new HashSet<CartProduct>();


    }
}
