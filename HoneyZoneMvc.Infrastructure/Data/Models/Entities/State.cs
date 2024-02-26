using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class State
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}