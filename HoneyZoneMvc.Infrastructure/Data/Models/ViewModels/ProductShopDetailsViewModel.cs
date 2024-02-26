using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels
{
    public class ProductShopDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int QuantityInStock { get; set; }

        public string ProductAmount { get; set; }

        public string MainImageName { get; set; }

        public string MainImageUrl { get; set; }

        public ICollection<string> ImagesNames { get; set; }



    }
}
