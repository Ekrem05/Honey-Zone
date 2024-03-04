using HoneyZoneMvc.Constraints;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels
{
    public class DiscountByCategoryViewModel
    {
        public string CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        [Range(DataConstants.Product.DiscountMinValue, DataConstants.Product.DiscountMaxValue, ErrorMessage = Messages.ExceptionMessages.ProductDiscountValueValidation)]
        public double Discount { get; set; }
    }
}
