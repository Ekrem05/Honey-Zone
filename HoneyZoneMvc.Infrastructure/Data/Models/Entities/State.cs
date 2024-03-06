using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class State
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(Constraints.DataConstants.State.NameMaxValue)]
        public string Name { get; set; } = string.Empty;
    }
}