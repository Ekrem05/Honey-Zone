using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;
using System.ComponentModel;
namespace HoneyZoneMvc.BusinessLogic.ViewModels.Product
{
    public class ProductEditViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        public Guid Id { get; set; } = Guid.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.NameMaxValue, MinimumLength = DataConstants.Product.NameMinValue, ErrorMessage = ProductNameValueValidation)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [DisplayName("Category")]
        public string CategoryId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Range(DataConstants.Product.PriceMinValue, DataConstants.Product.PriceMaxValue, ErrorMessage = ProductPriceValueValidation)]
        public double Price { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.DescriptionMaxValue, MinimumLength = DataConstants.Product.DescriptionMinValue, ErrorMessage = ProductDescriptionValueValidation)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(DataConstants.Product.InStockMinValue, DataConstants.Product.InStockMaxValue, ErrorMessage = ProductInStockValueValidation)]
        [DisplayName("Quantity In Stock")]
        public int QuantityInStock { get; set; }

        [Required]
        [RegularExpression(DataConstants.Product.AmountRegx, ErrorMessage = ProductAmountValueValidation)]
        [DisplayName("Product Amount")]
        public string ProductAmount { get; set; } = string.Empty;


        public IEnumerable<CategoryViewModel> Categories { get; set; }= new List<CategoryViewModel>();

    }
}
