using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Messages.ExceptionMessages;

namespace HoneyZoneMvc.Infrastructure.ViewModels.DTOs
{
    public class ProductDto
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.NameMaxValue, MinimumLength = DataConstants.Product.NameMinValue, ErrorMessage = ProductNameValueValidation)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public string Category { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Range(DataConstants.Product.PriceMinValue, DataConstants.Product.PriceMaxValue, ErrorMessage = ProductPriceValueValidation)]
        public double Price { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.DescriptionMaxValue, MinimumLength = DataConstants.Product.DescriptionMinValue, ErrorMessage = ProductDescriptionValueValidation)]
        public string Description { get; set; }

        [Required]
        [Range(DataConstants.Product.InStockMinValue, DataConstants.Product.InStockMaxValue, ErrorMessage = ProductInStockValueValidation)]
        public int QuantityInStock { get; set; }

        [Required]
        [RegularExpression("^\\d+\\s?(ml|l|g|mg|kg)$", ErrorMessage = ProductAmountValueValidation)]
        public string ProductAmount { get; set; }

        public string MainImageName { get; set; }

        public IFormFile MainImageFile { get; set; }

        public ICollection<ImageUrl> Images { get; set; }

        public ICollection<CategoryAddViewModel> Categories { get; set; }


        public string CategoryFilter { get; set; }

    }
}
