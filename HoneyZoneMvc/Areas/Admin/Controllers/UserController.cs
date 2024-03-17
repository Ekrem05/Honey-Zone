using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserController(RoleManager<ApplicationRole> _roleManager)
        {
          roleManager = _roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
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
