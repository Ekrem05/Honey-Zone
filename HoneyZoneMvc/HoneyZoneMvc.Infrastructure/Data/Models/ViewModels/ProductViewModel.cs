using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        public IEnumerable<CategoryDto> CategoryDtos { get; set; }
        public ProductDto ProductDtoPattern { get; set; }

    }
}
