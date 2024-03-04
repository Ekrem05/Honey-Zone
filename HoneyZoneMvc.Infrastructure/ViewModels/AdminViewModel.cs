using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.User;

namespace HoneyZoneMvc.Infrastructure.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<ProductAdminViewModel> Products { get; set; } = new List<ProductAdminViewModel>();
        public IEnumerable<OrderInfoViewModel> Orders { get; set; } = new List<OrderInfoViewModel>();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        public IEnumerable<UserViewModel> Users { get; set; } = new List<UserViewModel>();
        public DiscountByCategoryViewModel DiscountByCategoryViewModel { get; set; } = new DiscountByCategoryViewModel();
        

    }
}
