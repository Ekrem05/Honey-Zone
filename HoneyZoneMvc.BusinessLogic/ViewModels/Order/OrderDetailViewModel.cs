using static HoneyZoneMvc.Common.Messages.ValidationMessages;
using HoneyZoneMvc.BusinessLogic.ViewModels.Delivery;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
    
namespace HoneyZoneMvc.BusinessLogic.ViewModels.Order
{ 
    public class OrderDetailViewModel
    {
        [Required(ErrorMessage =RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.NameMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.NameMinValue,ErrorMessage = OrderDetailNameValueValidation)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.NameMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.NameMinValue, ErrorMessage = OrderDetailNameValueValidation)]
        public string SecondName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Phone]
        [StringLength(Constraints.DataConstants.OrderDetails.PhoneNumberMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.PhoneNumberMinValue, ErrorMessage = OrderDetailPhoneNumberValueValidation)]
        public string PhoneNumber { get; set; } = string.Empty;

        [AllowNull]
        [EmailAddress(ErrorMessage = OrderDetailEmailValueValidation)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.CityMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.CityMinValue, ErrorMessage = OrderDetailCityValueValidation)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.ZipCodeLength, MinimumLength = Constraints.DataConstants.OrderDetails.ZipCodeLength, ErrorMessage = OrderDetailZipCodeValueValidation)]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetails.AddressMaxValue, MinimumLength = Constraints.DataConstants.OrderDetails.AddressMinValue, ErrorMessage = OrderDetailAddressValueValidation)]
        public string Address { get; set; } = string.Empty;

       
        public string DeliveryMethodId { get; set; } = string.Empty;

        public IEnumerable<DeliveryMethodViewModel> DeliveryMethods { get; set; } = new List<DeliveryMethodViewModel>();
        public string TotalSum { get; set; } = string.Empty;
    }
}
