using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Common.Attributes
{
    public class DiscountRange: ValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public DiscountRange(int minValue,int maxValue)
        {
           this.minValue = minValue;
            this.maxValue = maxValue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (ProductEditViewModel)validationContext.ObjectInstance;
            if (model.IsDiscounted)
            {
                if (model.Discount>=minValue && model.Discount<=maxValue)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(this.ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
