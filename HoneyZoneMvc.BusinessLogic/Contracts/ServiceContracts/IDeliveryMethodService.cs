using HoneyZoneMvc.BusinessLogic.Contracts.SubContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IDeliveryService : ICrud<DeliveryMethodDto>
    {
    }
}
