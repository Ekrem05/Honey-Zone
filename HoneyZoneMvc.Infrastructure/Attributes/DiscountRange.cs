using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
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
        private string? errorMessage;
        public DiscountRange(int minValue,int maxValue,string? message)
        {
           this.minValue = minValue;
            this.maxValue = maxValue;
            this.errorMessage = message;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (ProductEditViewModel)validationContext.ObjectInstance;
            if (model.IsDiscounted)
            {
                if (model.Discount>=minValue&& model.Discount<=maxValue)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
