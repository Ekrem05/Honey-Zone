using HoneyZoneMvc.Constraints;
using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels
{
    public class CategoryAddViewModel
    {
        [Required]
        [StringLength(DataConstants.Category.NameMaxValue, MinimumLength = DataConstants.Category.NameMinValue, ErrorMessage = CategoryValidation)]
        public string Name { get; set; }

    }
}
