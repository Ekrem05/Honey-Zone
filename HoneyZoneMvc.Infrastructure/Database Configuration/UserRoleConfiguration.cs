using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyZoneMvc.Infrastructure.Database_Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
                UserId = Guid.Parse("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
            });
        }
    }
}
