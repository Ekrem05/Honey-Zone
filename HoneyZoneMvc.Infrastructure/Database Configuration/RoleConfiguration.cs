using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.Infrastructure.Database_Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
           builder.HasData(new ApplicationRole()
           {
               Id = Guid.Parse("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
               Name = "Admin",
               NormalizedName = "ADMIN",
               ConcurrencyStamp = Guid.NewGuid().ToString(),
           });
        }
    }
}
