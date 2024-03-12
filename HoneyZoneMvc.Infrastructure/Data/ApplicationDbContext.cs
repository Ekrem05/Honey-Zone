
using HoneyZoneMvc.Infrastructure.Configuration;
using HoneyZoneMvc.Infrastructure.Data.Models;
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

        public DbSet<Product> Products { get; set; }
        public DbSet<ImageUrl> ImageUrls { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<DeliveryMethod> DeliverMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<State> States { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new StateConfiguration());
            builder.ApplyConfiguration(new DeliveryMethodConfiguration());
            builder.ApplyConfiguration(new CartProductConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

