using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductAdminViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public bool IsDiscounted { get; set; }

        public double Discount { get; set; }

        public string Description { get; set; }

        public int QuantityInStock { get; set; }

        public string ProductAmount { get; set; }

        public string MainImageName { get; set; }

        public string[] Images { get; set; }

    }
}
