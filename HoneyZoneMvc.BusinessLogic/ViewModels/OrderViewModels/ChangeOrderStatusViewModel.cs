using HoneyZoneMvc.BusinessLogic.ViewModels.Status;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.OrderViewModels
{
    public class ChangeOrderStatusViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public IEnumerable<StatusViewModel> Statuses { get; set; } = new List<StatusViewModel>();
        public string StatusId { get; set; } = string.Empty;
    }
}
