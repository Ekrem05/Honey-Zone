using HoneyZoneMvc.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductDiscountViewModel
    {
        [Required]
        public string Id { get; set; }
        [Range(DataConstants.Product.DiscountMinValue,DataConstants.Product.DiscountMaxValue,ErrorMessage=Messages.ExceptionMessages.ProductDiscountValueValidation)]
        public double Discount { get; set; }
    }
}
