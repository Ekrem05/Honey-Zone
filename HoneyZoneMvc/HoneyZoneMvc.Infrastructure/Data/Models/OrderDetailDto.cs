using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class OrderDetailDto
    {
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

        public ICollection<DeliveryMethodDto> DeliveryMethods { get; set; }
    }
}
