﻿
namespace HoneyZoneMvc.BusinessLogic.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string[] Roles { get; set; }
    }
}
