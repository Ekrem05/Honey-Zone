using HoneyZoneMvc.BusinessLogic.Contracts.SubContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.User;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IUserService : IReadable<UserViewModel>
    {
        Task<AllUsersQueryModel> AllAsync(string role, string searchTerm, int currentPage, int usersPerPage);
        Task AddUserToRoleAsync(string roleName, string userId);
    }
}
