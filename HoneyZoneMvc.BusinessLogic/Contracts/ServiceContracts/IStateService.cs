using HoneyZoneMvc.Infrastructure.Data.Models.Entities;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IStateService
    {
        Task<State> GetInitialOrderState();
    }
}
