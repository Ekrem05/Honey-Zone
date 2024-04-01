using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyZoneMvc.Infrastructure.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
            .HasMany(p => p.Images)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);

            builder
             .HasData(new Product()
             {
                 Id = Guid.Parse("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                 Name = "Sunflower Honey",
                 CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                 Price = 19.99,
                 IsDiscounted = true,
                 Discount = 20,
                 Description = "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.",
                 QuantityInStock = 82,
                 ProductAmount = "800g",
                 TimesOrdered = 1,
                 MainImageUrl = "bg honey2.png"

             },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Acacia honey",
                 CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                 Price = 25.99,
                 IsDiscounted = false,
                 Description = "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.",
                 QuantityInStock = 27,
                 ProductAmount = "1kg",
                 TimesOrdered = 2,
                 MainImageUrl = "attachment_86137655.jpg"
             },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Manuka Honey",
                 CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                 Price = 18.99,
                 IsDiscounted = false,
                 Description = "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.",
                 QuantityInStock = 11,
                 ProductAmount = "1kg",
                 TimesOrdered = 3,
                 MainImageUrl = "black bg honey.png"
             },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Wildflower Pollen",
                 CategoryId = Guid.Parse("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                 Price = 55.99,
                 IsDiscounted = true,
                 Discount = 55,
                 Description = "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.",
                 QuantityInStock = 102,
                 ProductAmount = "2kg",
                 TimesOrdered = 0,
                 MainImageUrl = "bee-pollen-2549125_1280.jpg"
             },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Beeswax",
                 CategoryId = Guid.Parse("f4251d33-9582-4be6-8bea-be96dd30804e"),
                 Price = 31.99,
                 IsDiscounted = true,
                 Discount = 10,
                 Description = "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.",
                 QuantityInStock = 202,
                 ProductAmount = "900g",
                 TimesOrdered = 0,
                 MainImageUrl = "Fresh-beeswax-for-hair-on-the-table.jpg"
             },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Fridge Magnet",
                 CategoryId = Guid.Parse("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                 Price = 1.99,
                 IsDiscounted = false,
                 Description = "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!",
                 QuantityInStock = 100,
                 ProductAmount = "Single item",
                 TimesOrdered = 0,
                 MainImageUrl = "BeeMagnet.jpg"
             },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Coffee Cup",
                 CategoryId = Guid.Parse("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                 Price = 2.99,
                 IsDiscounted = false,
                 Description = "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.",
                 QuantityInStock = 50,
                 ProductAmount = "Single item",
                 TimesOrdered = 0,
                 MainImageUrl = "coffee-cup-bees.jpg"
             });
        }

    }
}