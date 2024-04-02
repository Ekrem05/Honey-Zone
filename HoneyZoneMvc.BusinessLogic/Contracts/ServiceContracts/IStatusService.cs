using HoneyZoneMvc.BusinessLogic.Contracts.SubContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Status;
using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IStatusService: IReadable<StatusViewModel>
    {
        Task<Status> GetInitialOrderStatus();

    }
}
