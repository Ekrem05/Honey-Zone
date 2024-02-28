using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;

namespace HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels
{
    public class ChangeOrderStatusViewModel
    {
        public string Id { get; set; }
        public string CurrentStatus { get; set; }
        public IEnumerable<StatusDto> Statuses { get; set; }
        public string StatusId { get; set; }
    }
}
