using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyZoneMvc.Infrastructure.Database_Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(new ApplicationUser()
            {
                Id = Guid.Parse("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                FirstName = "Admin",
                LastName = "Admin",
                Email = "administrator@gmail.com",
                UserName = "FirstAdmin",
                NormalizedEmail = "ADMINISTRATOR@GMAIL.COM",
                NormalizedUserName = "FIRSTADMIN",
                SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                PhoneNumberConfirmed = false,
                PasswordHash = passwordHasher.HashPassword(null, "Admin1234"),
                EmailConfirmed = false,
            });
        }
    }
}
