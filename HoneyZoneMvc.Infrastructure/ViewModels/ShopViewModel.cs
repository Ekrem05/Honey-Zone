using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.Infrastructure.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<ProductShopCardViewModel> Products { get; set; } = new List<ProductShopCardViewModel>();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
