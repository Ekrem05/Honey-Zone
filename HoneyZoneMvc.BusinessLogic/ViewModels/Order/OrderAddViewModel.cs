using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Order
{
    public class OrderAddViewModel
    {
        public double TotalSum { get; set; }

        public string DeliveryMethodId { get; set; }

        public string ClientId { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public string OrderDetailId { get; set; }

        public OrderDetailViewModel OrderDetail { get; set; } = null!;

        public IEnumerable<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
