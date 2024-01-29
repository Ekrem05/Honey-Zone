using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace HoneyZoneMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product>Products { get; set; }
        public DbSet<ImageName> ImageNames { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}

