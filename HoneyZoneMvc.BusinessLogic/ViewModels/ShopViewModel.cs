using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.BusinessLogic.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<ProductShopCardViewModel> Products { get; set; } = new List<ProductShopCardViewModel>();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
