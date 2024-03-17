using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.BusinessLogic.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserService(UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }
        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var users = await dbContext.Users.ToListAsync();

            var userViewModels = users.Select(async u => new UserViewModel
            {
                Id = u.Id.ToString(),
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Role = await GetRole(u)
            }).ToList();
            var completedViewModels = await Task.WhenAll(userViewModels);

            return completedViewModels;
        }

        private async Task<string> GetRole(ApplicationUser u)
        {
            if (await userManager.IsInRoleAsync(u, "Admin"))
            {
                return "Admin";
            }
            return "User";
        }
    }
}
