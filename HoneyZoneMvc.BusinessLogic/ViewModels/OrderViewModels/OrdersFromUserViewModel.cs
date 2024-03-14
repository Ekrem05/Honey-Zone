using HoneyZoneMvc.BusinessLogic.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.OrderViewModels
{
    public class OrdersFromUserViewModel
    {
        public string TotalSum { get; set; } = string.Empty;
        public string DeliveryMethod { get; set; } = string.Empty;
        public string OrderDate { get; set; } = string.Empty;
        public string ExpectedDelivery { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<ProductsOrderedUserViewModel> Products { get; set; } = new List<ProductsOrderedUserViewModel>();
    }
}
