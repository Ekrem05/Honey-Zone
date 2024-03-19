using Microsoft.AspNetCore.Identity;

namespace HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
