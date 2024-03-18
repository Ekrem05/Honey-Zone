using HoneyZoneMvc.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.User
{
    public class AllUsersQueryModel
    {
        public int UsersPerPage { get; } = 3;

        public string Role { get; set; } = "All";

        public string SearchTerm { get; set; } = string.Empty;

        public int CurrentPage { get; init; } = 1;

        public int TotalUsers { get; set; }

        public IEnumerable<string> Roles { get; set; } = new HashSet<string>();

        public IEnumerable<UserViewModel> Users { get; set; } = new List<UserViewModel>();
    }
}
