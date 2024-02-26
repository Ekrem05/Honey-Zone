using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyZoneMvc.Models.Entities
{
    public class ImageName
    {

        [Key]
        public int Id { get; set; }
        [Required]

        [MaxLength(60)]
        public string Name { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
