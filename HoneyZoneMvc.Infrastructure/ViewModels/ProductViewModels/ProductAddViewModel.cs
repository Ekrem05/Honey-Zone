using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static HoneyZoneMvc.Messages.ExceptionMessages;
namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductAddViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.NameMaxValue, MinimumLength = DataConstants.Product.NameMinValue, ErrorMessage = ProductNameValueValidation)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Range(DataConstants.Product.PriceMinValue, DataConstants.Product.PriceMaxValue, ErrorMessage = ProductPriceValueValidation)]
        public double Price { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public bool IsDiscounted { get; set; }

        [AllowNull]
        [Range(DataConstants.Product.DiscountMinValue, DataConstants.Product.DiscountMaxValue, ErrorMessage = ProductDiscountValueValidation)]
        public double Discount { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.DescriptionMaxValue, MinimumLength = DataConstants.Product.DescriptionMinValue, ErrorMessage = ProductDescriptionValueValidation)]
        public string Description { get; set; }

        [Required]
        [Range(DataConstants.Product.InStockMinValue, DataConstants.Product.InStockMaxValue, ErrorMessage = ProductInStockValueValidation)]
        public int QuantityInStock { get; set; }

        [Required]
        [RegularExpression("^\\d+\\s?(ml|l|g|mg|kg)$", ErrorMessage = ProductAmountValueValidation)]
        public string ProductAmount { get; set; }

        public IFormFile MainImage { get; set; }

        public ICollection<IFormFile> Images { get; set; }

        public IEnumerable<CategoryAddViewModel> Categories { get; set; }


    }
}
