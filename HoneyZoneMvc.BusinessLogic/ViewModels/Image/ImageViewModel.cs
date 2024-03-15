using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Image
{
    public class ImageViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public IFormFile imageFile { get; set; } = null!;
    }
}
