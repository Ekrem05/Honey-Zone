using HoneyZoneMvc.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Product
{
    public class AllProductsQueryModel
    {
        public int ProductsPerPage { get; } = 3;

        public string Category { get; set; } = string.Empty;

        public string SearchTerm { get; set; } = string.Empty;

        public ProductSorting SortBy { get; set; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<ProductAdminViewModel> Products { get; set; } = new List<ProductAdminViewModel>();
    }
}
