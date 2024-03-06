using HoneyZoneMvc.Constraints;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyZoneMvc.Models.Entities
{
    public class ImageUrl
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.ImageUrl.NameMaxValue)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

    }
}
