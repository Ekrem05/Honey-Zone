using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IStatusService
    {
        Task<State> GetInitialOrderStatus();
        Task<IEnumerable<StatusDto>> GetAllAsync();

    }
}
