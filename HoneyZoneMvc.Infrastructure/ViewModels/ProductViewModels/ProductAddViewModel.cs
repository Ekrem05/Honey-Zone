using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;
namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductAddViewModel
    {

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.NameMaxValue, MinimumLength = DataConstants.Product.NameMinValue, ErrorMessage = ProductNameValueValidation)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        public string CategoryId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Range(DataConstants.Product.PriceMinValue, DataConstants.Product.PriceMaxValue, ErrorMessage = ProductPriceValueValidation)]
        public double Price { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.DescriptionMaxValue, MinimumLength = DataConstants.Product.DescriptionMinValue, ErrorMessage = ProductDescriptionValueValidation)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(DataConstants.Product.InStockMinValue, DataConstants.Product.InStockMaxValue, ErrorMessage = ProductInStockValueValidation)]
        public int QuantityInStock { get; set; }

        [Required]
        [RegularExpression("^\\d+\\s?(ml|l|g|mg|kg)$", ErrorMessage = ProductAmountValueValidation)]
        public string ProductAmount { get; set; } = string.Empty;

        public IFormFile MainImage { get; set; } = null!;

        public ICollection<IFormFile> Images { get; set; } = new List<IFormFile>();

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();


    }
}
