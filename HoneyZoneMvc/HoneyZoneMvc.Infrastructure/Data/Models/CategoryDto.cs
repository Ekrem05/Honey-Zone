using HoneyZoneMvc.Constraints;
using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Messages.ExceptionMessages;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(DataConstants.Category.NameMaxValue, MinimumLength = DataConstants.Category.NameMinValue, ErrorMessage = CategoryValidation)]
        public string Name { get; set; }

    }
}
