using HoneyZoneMvc.BusinessLogic.ViewModels.User;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
    }
}
