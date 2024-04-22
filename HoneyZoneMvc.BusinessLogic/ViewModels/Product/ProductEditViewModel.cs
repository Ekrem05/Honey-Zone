using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Constraints;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;
namespace HoneyZoneMvc.BusinessLogic.ViewModels.Product
{
    public class ProductEditViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        public Guid Id { get; set; } = Guid.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.NameMaxValue, MinimumLength = DataConstants.Product.NameMinValue, ErrorMessage = ProductNameValueValidation)]
        [DisplayName("Име")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [DisplayName("Категория")]
        public string CategoryId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Range(DataConstants.Product.PriceMinValue, DataConstants.Product.PriceMaxValue, ErrorMessage = ProductPriceValueValidation)]
        [DisplayName("Цена")]
        public double Price { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DataConstants.Product.DescriptionMaxValue, MinimumLength = DataConstants.Product.DescriptionMinValue, ErrorMessage = ProductDescriptionValueValidation)]
        [DisplayName("Описание")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(DataConstants.Product.InStockMinValue, DataConstants.Product.InStockMaxValue, ErrorMessage = ProductInStockValueValidation)]
        [DisplayName("Количество в склад")]
        public int QuantityInStock { get; set; }

        [Required]
        [RegularExpression(DataConstants.Product.AmountRegx, ErrorMessage = ProductAmountValueValidation)]
        [DisplayName("Разфасофка")]
        public string ProductAmount { get; set; } = string.Empty;


        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

    }
}