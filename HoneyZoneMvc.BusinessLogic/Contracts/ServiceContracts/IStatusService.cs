using HoneyZoneMvc.BusinessLogic.ViewModels.Status;
using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IStatusService
    {
        Task<Status> GetInitialOrderStatus();
        Task<IEnumerable<StatusViewModel>> GetAllAsync();

    }
}
