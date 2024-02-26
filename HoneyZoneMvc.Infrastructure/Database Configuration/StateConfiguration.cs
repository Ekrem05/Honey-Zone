using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyZoneMvc.Infrastructure.Configuration
{
    internal class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
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
        }
    }
}