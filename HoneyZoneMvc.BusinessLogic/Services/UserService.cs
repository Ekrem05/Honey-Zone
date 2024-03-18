using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.BusinessLogic.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;
using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserService( UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task AddUserToRoleAsync(string roleName, string userId)
        {
            if (roleName==null||userId==null)
            {
                throw new ArgumentNullException();
            }
            var user= await userManager.FindByIdAsync(userId);
            if (user==null)
            {
                throw new ArgumentNullException();
            }
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });
            }
            if (!await userManager.IsInRoleAsync(user,roleName))
            {
                await userManager.AddToRoleAsync(user, roleName);
            }
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            var users = await userManager.Users.ToListAsync();
            List<UserViewModel> userViewModels= new List<UserViewModel>();
            foreach (var user in users)
            {
                UserViewModel vm = new UserViewModel()
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = await GetUserRole(user)
                };
                userViewModels.Add(vm);
            }
            return userViewModels;

        }

        public async Task<AllUsersQueryModel> AllAsync(string role, string searchTerm, int currentPage=1,int usersPerPage=1)
        {
            var users = await userManager.Users.ToListAsync();
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            if (role!="All")
            {
                users=(await userManager.GetUsersInRoleAsync(role)).ToList();
            }
            if (searchTerm != null)
            {
                users = users.Where(x => x.Email.ToLower()
                .Contains(searchTerm.ToLower()) || 
                x.FirstName.ToLower().Contains(searchTerm.ToLower()) ||
                x.LastName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            var usersToShow = users
               .Skip((currentPage - 1) * usersPerPage)
               .Take(usersPerPage)
               .ToList();
            foreach (var user in usersToShow)
            {
                UserViewModel vm = new UserViewModel()
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = await GetUserRole(user)
                };
                userViewModels.Add(vm);
            }
            AllUsersQueryModel model = new AllUsersQueryModel()
            {
                Users = userViewModels,
                CurrentPage = currentPage,
                TotalUsers = users.Count,
                Roles = roleManager.Roles.Select(x => x.Name).ToList()
            };
            return model;
        }

        public Task<UserViewModel> GetByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserViewModel>> GetByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }
        private async Task<string[]> GetUserRole(ApplicationUser user)
        {
            return (await userManager.GetRolesAsync(user)).ToArray();
        }

    }
}
