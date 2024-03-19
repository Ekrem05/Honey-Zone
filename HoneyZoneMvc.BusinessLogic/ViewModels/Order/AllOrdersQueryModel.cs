using HoneyZoneMvc.BusinessLogic.Enums;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Order
{
    public class AllOrdersQueryModel
    {

        public int OrdersPerPage { get; } = 3;

        public int Day { get; set; } = 0;

        public int Month { get; set; } = 0;

        public int Year { get; set; } = 0;

        public string SearchTerm { get; set; } = string.Empty;

        public OrderSorting SortBy { get; set; }

        public int CurrentPage { get; init; } = 1;

        public int TotalOrdersCount { get; set; }

        public IEnumerable<string> Deliveries { get; set; } = null!;

        public IEnumerable<OrderAdminViewModel> Orders { get; set; } = new List<OrderAdminViewModel>();
    }
}
