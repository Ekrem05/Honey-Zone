using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels
{
    public class OrderInfoViewModel
    {
        public string Id { get; set; }

        public string TotalSum { get; set; }

        public string DeliveryMethod { get; set; }

        public string ClientName { get; set; }

        public string OrderDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string ExpectedDelivery { get; set; }

        public string State { get; set; }

        public List<ProductOrderedAdminViewModel> Products { get; set; } = new List<ProductOrderedAdminViewModel>();
    }
}
