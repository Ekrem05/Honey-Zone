﻿using HoneyZoneMvc.Constraints;
using System.ComponentModel.DataAnnotations;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Category.NameMaxValue)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
