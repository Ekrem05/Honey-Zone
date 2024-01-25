using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Models.Entities;
using HoneyZoneMvc.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Constraints.ValidationValues;
using static HoneyZoneMvc.Messages.ExceptionMessages;

namespace HoneyZoneMvc.Models.ViewModels
{
    public class ProductDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(ProductNameMaxValue,MinimumLength = ProductNameMinValue,ErrorMessage = ProductNameValueValidation)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public string Category { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Range(ProductPriceMinValue, ProductPriceMaxValue,ErrorMessage = ProductPriceValueValidation)]
        public double Price { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(ProductDescriptionMaxValue, MinimumLength = ProductDescriptionMinValue, ErrorMessage = ProductDescriptionValueValidation)]
        public string Description { get; set; }

        [Required]
        [Range(ProductInStockMinValue, ProductInStockMaxValue, ErrorMessage = ProductInStockValueValidation)]
        public int QuantityInStock { get; set; }

        [Required]
        [RegularExpression("^\\d+\\s?(ml|l|g|mg|kg)$", ErrorMessage = ProductQuantityValueValidation)]
        public string ProductQuantity { get; set; }

        public string MainImageName { get; set; }

        public IFormFile MainImageFile{ get; set; }

        public ICollection<ImageName> ImagesNames { get; set; }

        public string CategoryFilter { get; set; }

    }
}
