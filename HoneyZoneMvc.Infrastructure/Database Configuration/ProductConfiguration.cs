using HoneyZoneMvc.Models.Entities;
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
                 Id = Guid.NewGuid(),
                 Name = "Слънчогледов мед",
                 CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                 Price = 19.99,
                 IsDiscounted=true,
                 Discount=20,
                 Description = "Слънчогледовият мед е уникален продукт, получен от нектара на цветовете на слънчогледа. Този вид мед се отличава с лек, сладък вкус и ярко златист цвят. Ароматът му е нежен и приятен, с леки оттенъци на цветя. Слънчогледовият мед често се характеризира със средна до по-плътна консистенция и може да кристализира с времето, образувайки фини кристали. Този процес не влияе на качествата на меда и може бързо да се възстанови до течно състояние с леко загряване.",
                 QuantityInStock = 82,
                 ProductAmount = "800г",
                 MainImageUrl = "bg honey2.png"

             },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Акациев мед",
                 CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                 Price = 25.99,
                 IsDiscounted = false,
                 Description = "Акациевият мед е светъл и благороден, със свеж и деликатен вкус. Произведен от цветята на акацията, този мед е изключително чист и прозрачен. Сладък аромат и лека консистенция правят акациевия мед предпочитан избор. Също така се цени за потенциалните му благоприятни върху здравето свойства, като антибактериални и противовъзпалителни ефекти. Възможно е да бъде употребяван самостоятелно или като добавка към различни ястия и напитки.",
                 QuantityInStock = 27,
                 ProductAmount = "1кг",
                 MainImageUrl = "attachment_86137655.jpg"
             },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Горски прашец",
                 CategoryId = Guid.Parse("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                 Price = 55.99,
                 IsDiscounted = true,
                 Discount = 55,
                 Description = "Горският прашец е пчелен продукт, събран от пчели в горите от различни дървесни видове. Той е плътен и карамелен по цвят, с интензивен аромат и сладък вкус. Горският прашец е известен със своите богати хранителни и лечебни свойства, като се счита за естествен източник на витамини, минерали и антиоксиданти. Често се използва като добавка към храна или напитки за подобряване на имунната система и засилване на енергията.",
                 QuantityInStock = 102,
                 ProductAmount = "2кг",
                 MainImageUrl = "bee-pollen-2549125_1280.jpg"
             });
        }
    }
}