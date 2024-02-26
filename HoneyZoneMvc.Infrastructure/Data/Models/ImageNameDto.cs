using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class ImageNameDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IFormFile imageFile { get; set; }
    }
}
