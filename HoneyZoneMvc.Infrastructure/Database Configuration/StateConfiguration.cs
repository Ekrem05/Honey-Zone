using HoneyZoneMvc.Infrastructure.Data.Models;
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
                   Name = "Confirmed"
               },
               new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "Pending"
               },
               new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "Sent"
               },
               new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "Delivered"
               },
               new State()
               {
                   Id = Guid.NewGuid(),
                   Name = "Cancelled"
               });
        }
    }
}