using HoneyZoneMvc.Constraints;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static HoneyZoneMvc.Common.Messages.ValidationMessages;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DataConstants.OrderDetail.NameMaxValue)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetail.NameMaxValue)]

        public string SecondName { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetail.PhoneNumberMaxValue)]
        public string PhoneNumber { get; set; } = string.Empty;

        [AllowNull]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetail.CityMaxValue)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetail.ZipCodeLength)]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.OrderDetail.AddressMaxValue)]
        public string Address { get; set; } = string.Empty;

    }
}