using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class State
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(Constraints.DataConstants.Satus.NameMaxValue)]
        public string Name { get; set; } = string.Empty;
    }
}