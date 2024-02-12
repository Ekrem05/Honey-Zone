using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Category.NameMaxValue)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
