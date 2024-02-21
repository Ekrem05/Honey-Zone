using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Category.NameMaxValue)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
