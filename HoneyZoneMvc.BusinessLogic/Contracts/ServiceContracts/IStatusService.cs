using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.ViewModels.Status;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IStatusService
    {
        Task<State> GetInitialOrderStatus();
        Task<IEnumerable<StatusViewModel>> GetAllAsync();

    }
}
