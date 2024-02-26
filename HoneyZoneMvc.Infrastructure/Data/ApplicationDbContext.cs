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
                    Id = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                    Name = "Мед"
                },
                new Category()
                {
                    Id = Guid.Parse("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                    Name = "Прашец"
                },
                new Category()
                {
                    Id = Guid.Parse("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
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
            builder
              .Entity<Product>()
              .HasData(new Product()
              {
                  Id = Guid.NewGuid(),
                  Name = "Слънчогледов мед",
                  CategoryId= Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                  Price=19.99,
                  Description= "Слънчогледовият мед е уникален продукт, получен от нектара на цветовете на слънчогледа. Този вид мед се отличава с лек, сладък вкус и ярко златист цвят. Ароматът му е нежен и приятен, с леки оттенъци на цветя. Слънчогледовият мед често се характеризира със средна до по-плътна консистенция и може да кристализира с времето, образувайки фини кристали. Този процес не влияе на качествата на меда и може бързо да се възстанови до течно състояние с леко загряване.",
                  QuantityInStock=82,
                  ProductAmount="800г",
                  MainImageName= "bg honey2.png"

              },
              new Product()
              {
                  Id = Guid.NewGuid(),
                  Name = "Акациев мед",
                  CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                  Price = 25.99,
                  Description = "Акациевият мед е светъл и благороден, със свеж и деликатен вкус. Произведен от цветята на акацията, този мед е изключително чист и прозрачен. Сладък аромат и лека консистенция правят акациевия мед предпочитан избор. Също така се цени за потенциалните му благоприятни върху здравето свойства, като антибактериални и противовъзпалителни ефекти. Възможно е да бъде употребяван самостоятелно или като добавка към различни ястия и напитки.",
                  QuantityInStock = 27,
                  ProductAmount = "1кг",
                  MainImageName = "attachment_86137655.jpg"
              },
              new Product()
              {
                  Id = Guid.NewGuid(),
                  Name = "Горски прашец",
                  CategoryId = Guid.Parse("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                  Price = 55.99,
                  Description = "Горският прашец е пчелен продукт, събран от пчели в горите от различни дървесни видове. Той е плътен и карамелен по цвят, с интензивен аромат и сладък вкус. Горският прашец е известен със своите богати хранителни и лечебни свойства, като се счита за естествен източник на витамини, минерали и антиоксиданти. Често се използва като добавка към храна или напитки за подобряване на имунната система и засилване на енергията.",
                  QuantityInStock = 102,
                  ProductAmount = "2кг",
                  MainImageName = "bee-pollen-2549125_1280.jpg"
              });
            base.OnModelCreating(builder);
        }
    }
}

