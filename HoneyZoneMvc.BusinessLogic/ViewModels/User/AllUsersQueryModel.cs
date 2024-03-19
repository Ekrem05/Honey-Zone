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
