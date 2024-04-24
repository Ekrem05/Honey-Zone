using HoneyZoneMvc.BusinessLogic.ViewModels.Delivery;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Order
{
    public class OrderDetailViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.NameMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.NameMinValue, ErrorMessage = OrderDetailNameValueValidation)]
        [DisplayName("Име ")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.NameMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.NameMinValue, ErrorMessage = OrderDetailNameValueValidation)]
        [DisplayName("Фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Phone]
        [StringLength(Constraints.DataConstants.OrderDetails.PhoneNumberMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.PhoneNumberMinValue, ErrorMessage = OrderDetailPhoneNumberValueValidation)]
        [DisplayName("Телефонен номер")]
        public string PhoneNumber { get; set; } = string.Empty;

        [AllowNull]
        [EmailAddress(ErrorMessage = OrderDetailEmailValueValidation)]
        [DisplayName("Е-поща")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.CityMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.CityMinValue, ErrorMessage = OrderDetailCityValueValidation)]
        [DisplayName("Град")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.ZipCodeLength, MinimumLength = Constraints.DataConstants.OrderDetails.ZipCodeLength, ErrorMessage = OrderDetailZipCodeValueValidation)]
        [DisplayName("Пощенски код")]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.AddressMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.AddressMinValue, ErrorMessage = OrderDetailAddressValueValidation)]
        [DisplayName("Адрес")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [DisplayName("Куриер")]
        public string DeliveryMethodId { get; set; } = string.Empty;

        public IEnumerable<DeliveryMethodViewModel> DeliveryMethods { get; set; } = new List<DeliveryMethodViewModel>();
        public string TotalSum { get; set; } = string.Empty;
    }
}
