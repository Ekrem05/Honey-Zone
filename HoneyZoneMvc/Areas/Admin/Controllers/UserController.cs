using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels.User;
using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IUserService userService;

        public UserController(RoleManager<ApplicationRole> _roleManager, IUserService _userService)
        {
            roleManager = _roleManager;
            userService = _userService;
        }
        public async Task<IActionResult> Index([FromQuery]AllUsersQueryModel model)
        {
            AllUsersQueryModel vm=await userService
                .AllAsync(model.Role, model.SearchTerm, model.CurrentPage,model.UsersPerPage);
            
            model.TotalUsers = vm.TotalUsers;
            model.Roles = vm.Roles;
            model.Users = vm.Users;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(string roleName,string userId)
        {
            var result = await roleManager.RoleExistsAsync(roleName);
            if (result == false)
            {
                var role = new ApplicationRole()
                {
                    Name = roleName
                };

                await roleManager.CreateAsync(role);
            }


            return RedirectToAction("Index", "Home");
        }
    }
}
