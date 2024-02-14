
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HoneyZoneMvc.Constraints;


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
        public int CategoryId { get; set; }
        [Required]
        public Category Category {  get; set; }

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
        public string MainImageName { get; set; }

        [Required]
        public ICollection<ImageName> ImageNames = new List<ImageName>();

        [Required]
        public ICollection<OrderDetails> OrderDetails = new HashSet<OrderDetails>();

        [Required]
        public ICollection<CartProduct> CartProducts = new HashSet<CartProduct>();
    }
}
