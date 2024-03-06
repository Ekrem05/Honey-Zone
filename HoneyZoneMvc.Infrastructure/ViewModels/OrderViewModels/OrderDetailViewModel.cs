using static HoneyZoneMvc.Common.Messages.ValidationMessages;
using HoneyZoneMvc.Infrastructure.ViewModels.Delivery;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels
{
    public class OrderDetailViewModel
    {
        [Required(ErrorMessage =RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetail.NameMaxValue, MinimumLength = Constraints.DataConstants.OrderDetail.NameMinValue,ErrorMessage = OrderDetailNameValueValidation)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetail.NameMaxValue, MinimumLength = Constraints.DataConstants.OrderDetail.NameMinValue, ErrorMessage = OrderDetailNameValueValidation)]
        public string SecondName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Phone]
        [StringLength(Constraints.DataConstants.OrderDetail.PhoneNumberMaxValue, MinimumLength = Constraints.DataConstants.OrderDetail.PhoneNumberMinValue, ErrorMessage = OrderDetailPhoneNumberValueValidation)]
        public string PhoneNumber { get; set; } = string.Empty;

        [AllowNull]
        [EmailAddress(ErrorMessage = OrderDetailEmailValueValidation)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetail.CityMaxValue, MinimumLength = Constraints.DataConstants.OrderDetail.CityMinValue, ErrorMessage = OrderDetailCityValueValidation)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetail.ZipCodeLength, MinimumLength = Constraints.DataConstants.OrderDetail.ZipCodeLength, ErrorMessage = OrderDetailZipCodeValueValidation)]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(Constraints.DataConstants.OrderDetail.AddressMaxValue, MinimumLength = Constraints.DataConstants.OrderDetail.AddressMinValue, ErrorMessage = OrderDetailAddressValueValidation)]
        public string Address { get; set; } = string.Empty;

       
        public string DeliveryMethodId { get; set; } = string.Empty;

        public ICollection<DeliveryMethodViewModel> DeliveryMethods { get; set; } = new List<DeliveryMethodViewModel>();
        public string TotalSum { get; set; } = string.Empty;
    }
}
