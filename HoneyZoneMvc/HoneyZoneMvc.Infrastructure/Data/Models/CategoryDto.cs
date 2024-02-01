﻿using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static HoneyZoneMvc.Constraints.ValidationValues;
using static HoneyZoneMvc.Messages.ExceptionMessages;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxValue, MinimumLength = CategoryNameMinValue, ErrorMessage = CategoryValidation)]
        public string Name { get; set; }

    }
}