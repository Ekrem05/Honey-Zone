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

        public DbSet<Product> Products { get; set; }
        public DbSet<ImageName> ImageNames { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<DeliveryMethod> DeliverMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<State> States { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CartProduct>()
                 .HasKey(cp => new { cp.ClientId, cp.ProductId });


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
            builder
               .Entity<DeliveryMethod>()
               .HasData(new DeliveryMethod()
               {
                   Id = Guid.NewGuid(),
                   Name = "Спиди"
               },
               new DeliveryMethod()
               {
                   Id = Guid.NewGuid(),
                   Name = "Eконт"
               },
               new DeliveryMethod()
               {
                   Id = Guid.NewGuid(),
                   Name = "Сувенири"
               });
            builder
               .Entity<State>()
               .HasData(new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "Получена"
               },
               new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "В обработка"
               },
               new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "Изпратена"
               },
               new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "Доставена"
               },
               new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "Отменена"
               });
            
            base.OnModelCreating(builder);
        }
    }
}

