using HoneyZoneMvc.Common.Attributes;
using HoneyZoneMvc.Common.Messages;
using HoneyZoneMvc.Constraints;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductDiscountViewModel
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Range(DataConstants.Product.DiscountMinValue, DataConstants.Product.DiscountMaxValue, ErrorMessage = ValidationMessages.ProductDiscountValueValidation)]
        public double Discount { get; set; }
    }
}
