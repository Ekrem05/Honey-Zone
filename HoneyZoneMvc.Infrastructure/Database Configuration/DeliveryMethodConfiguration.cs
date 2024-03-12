using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyZoneMvc.Infrastructure.Configuration
{
    internal class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder
                 .HasData(new DeliveryMethod()
                 {
                     Id = Guid.NewGuid(),
                     Name = "Speedy"
                 },
                 new DeliveryMethod()
                 {
                     Id = Guid.NewGuid(),
                     Name = "Econt"
                 });
        }
    }
}