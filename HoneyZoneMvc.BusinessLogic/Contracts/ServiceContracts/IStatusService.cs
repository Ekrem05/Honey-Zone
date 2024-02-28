using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IStatusService
    {
        Task<State> GetInitialOrderStatus();
        Task<IEnumerable<StatusDto>> GetAllAsync();

    }
}
