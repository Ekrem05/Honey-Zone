using HoneyZoneMvc.Common.Messages;
using HoneyZoneMvc.Constraints;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Product
{
    public class ProductDiscountViewModel
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Range(DataConstants.Product.DiscountMinValue, DataConstants.Product.DiscountMaxValue, ErrorMessage = ValidationMessages.ProductDiscountValueValidation)]
        [DisplayName("Отстъпка")]
        public double Discount { get; set; }
    }
}
