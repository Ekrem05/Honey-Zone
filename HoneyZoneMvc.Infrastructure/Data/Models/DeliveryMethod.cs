﻿using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class DeliveryMethod
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(Constraints.DataConstants.DeliveryMethod.NameMaxValue)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}