using HoneyZoneMvc.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels
{
    public class DiscountByCategoryViewModel
    {
        public string CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }=new List<CategoryViewModel>();
        [Range(DataConstants.Product.DiscountMinValue, DataConstants.Product.DiscountMaxValue, ErrorMessage = Messages.ExceptionMessages.ProductDiscountValueValidation)]
        public double Discount { get; set; }
    }
}
