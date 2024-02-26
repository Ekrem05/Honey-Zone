using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyZoneMvc.Infrastructure.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
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
        }
    }
}