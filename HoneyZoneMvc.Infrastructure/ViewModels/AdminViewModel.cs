using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.Infrastructure.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<ProductAdminViewModel> Products { get; set; }
        public IEnumerable<OrderInfoViewModel> Orders { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
        public string ErrorMessage { get; set; }

    }
}
