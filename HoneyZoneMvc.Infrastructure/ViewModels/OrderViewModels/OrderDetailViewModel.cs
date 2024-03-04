using HoneyZoneMvc.Infrastructure.ViewModels.Delivery;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels
{
    public class OrderDetailViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string SecondName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [AllowNull]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string DeliveryMethodId { get; set; } = string.Empty;

        public ICollection<DeliveryMethodViewModel> DeliveryMethods { get; set; } = new List<DeliveryMethodViewModel>();
        public string TotalSum { get; set; } = string.Empty;
    }
}
