using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
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
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryMethod> DeliverMethods{ get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CartProduct>()
                 .HasKey(cp => new { cp.ClientId, cp.ProductId });
            builder.Entity<OrderDetails>()
                 .HasKey(cp => new { cp.ProducId, cp.OrderId});

            builder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Мед"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Прашец"
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Сувенири"
                });

            base.OnModelCreating(builder);
        }
    }
}

