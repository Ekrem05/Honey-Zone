﻿using HoneyZoneMvc.Infrastructure.ViewModels.Status;

namespace HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels
{
    public class ChangeOrderStatusViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public IEnumerable<StatusViewModel> Statuses { get; set; } = new List<StatusViewModel>();
        public string StatusId { get; set; } = string.Empty;
    }
}
