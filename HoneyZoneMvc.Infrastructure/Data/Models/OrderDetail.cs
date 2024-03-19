using HoneyZoneMvc.Constraints;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DataConstants.OrderDetails.NameMaxValue)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetails.NameMaxValue)]

        public string SecondName { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetails.PhoneNumberMaxValue)]
        public string PhoneNumber { get; set; } = string.Empty;

        [AllowNull]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetails.CityMaxValue)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetails.ZipCodeLength)]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetails.AddressMaxValue)]
        public string Address { get; set; } = string.Empty;

    }
}