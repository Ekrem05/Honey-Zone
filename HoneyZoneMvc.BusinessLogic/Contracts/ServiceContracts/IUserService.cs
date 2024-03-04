using HoneyZoneMvc.Infrastructure.ViewModels.User;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
    }
}
