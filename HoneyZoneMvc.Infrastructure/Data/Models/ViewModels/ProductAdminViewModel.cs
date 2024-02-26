using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels
{
    public class ProductAdminViewModel
    {
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        
    }
}
