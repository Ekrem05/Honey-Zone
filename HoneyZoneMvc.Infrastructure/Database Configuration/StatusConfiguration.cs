using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyZoneMvc.Infrastructure.Configuration
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder
               .HasData(new Status()
               {
                   Id = Guid.NewGuid(),
                   Name = "Confirmed"
               },
               new Status()
               {
                   Id = Guid.NewGuid(),
                   Name = "Pending"
               },
               new Status()
               {
                   Id = Guid.NewGuid(),
                   Name = "Sent"
               },
               new Status()
               {
                   Id = Guid.NewGuid(),
                   Name = "Delivered"
               },
               new Status()
               {
                   Id = Guid.NewGuid(),
                   Name = "Cancelled"
               });
        }
    }
}