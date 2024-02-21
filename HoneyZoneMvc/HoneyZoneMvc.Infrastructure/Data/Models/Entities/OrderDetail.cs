using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [AllowNull]
        public string Email { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Address { get; set; }
    }
}