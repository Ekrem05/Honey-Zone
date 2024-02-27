using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels.OrderViewModels
{
    public class ChangeOrderStatusViewModel
    {
        public string Id { get; set; }
        public string CurrentStatus { get; set; }
        public IEnumerable<StatusDto> Statuses { get; set; }
        public string StatusId { get; set; }
    }
}
