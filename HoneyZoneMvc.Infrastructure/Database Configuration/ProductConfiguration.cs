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
                 Name = "Слънчогледов мед",
                 CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                 Price = 19.99,
                 IsDiscounted = true,
                 Discount = 20,
                 Description = "Насладете се на златистистият вкус на нашия слънчогледов мед. С богатия си, цветен аромат и силен вкус, този мед е истинско удоволствие. Събран от живите цветя на слънчогледите, той се отличава с гладка текстура и леко орехов сладникав вкус. Идеален за добавяне на допир от слънце към вашето сутрешно чайче или за поръсване върху свежо изпечени изделия. Преживейте чистия вкус на природата с нашия слънчогледов мед.",
                 QuantityInStock = 82,
                 ProductAmount = "800g",
                 TimesOrdered = 1,
                 MainImageUrl = "bg honey2.png"

             },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Акациев мед",
                CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                Price = 25.99,
                IsDiscounted = false,
                Description = "Акациевият мед е светъл, почти безцветен и прозрачен, с лек аромат на цветя. Има фина текстура и деликатен вкус, който може да варира от леко сладък до умерено сладък в зависимост от източника на нектар. Често се използва в готвенето и печенето поради естествената си сладост и мек вкус.",
                QuantityInStock = 27,
                ProductAmount = "1kg",
                TimesOrdered = 2,
                MainImageUrl = "attachment_86137655.jpg"
            },
             new Product()
             {
                 Id = Guid.NewGuid(),
                 Name = "Манов мед",
                 CategoryId = Guid.Parse("78355d47-6040-4676-9972-ac8be4f19882"),
                 Price = 18.99,
                 IsDiscounted = false,
                 Description = "Потопете се в изискания вкус и ползите за здравето на мановият мед. Произведен от чистите пейзажи на Нова Зеландия, този рядък мед е известен с богатия си вкус и мощните си лечебни свойства. Със своите уникални антибактериални и антиоксидантни качества, медът Манука предлага естествено стимулиране на имунната ви система и стимулира общото ви благополучие.",
                 QuantityInStock = 11,
                 ProductAmount = "1kg",
                 TimesOrdered = 3,
                 MainImageUrl = "black bg honey.png"
             },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Пчелен прашец",
                CategoryId = Guid.Parse("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                Price = 55.99,
                IsDiscounted = true,
                Discount = 55,
                Description = "Открийте силата на природата с нашия премиум продукт от пчелен прашец. Пълен с хранителни вещества и събран от най-добрите източници, нашият пчелен прашец е естествено стимулиращ за здравето ви и рутината за благополучие. Просто поръсете го върху любимите си храни или го смесете в смутита за вкусно и хранително допълнение. Дайте енергия на деня си по естествен начин с нашия пчелен прашец.",
                QuantityInStock = 102,
                ProductAmount = "2kg",
                TimesOrdered = 0,
                MainImageUrl = "bee-pollen-2549125_1280.jpg"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Пчелен восък",
                CategoryId = Guid.Parse("f4251d33-9582-4be6-8bea-be96dd30804e"),
                Price = 31.99,
                IsDiscounted = true,
                Discount = 10,
                Description = "Открийте универсалната красота на чистия пчелен восък. Известен с естествения си аромат и златист цвят, пчелният восък е универсална съставка, използвана в свещи, козметични продукти и други. Създаден от пчели с прецизност, той предлага нежна, защитна бариера за кожата ви и топъл, пригласителен блясък, когато се запали. Прегърнете вечната елегантност и естествената привлекателност на пчелния восък в ежедневните си ритуали.",
                QuantityInStock = 202,
                ProductAmount = "900g",
                TimesOrdered = 0,
                MainImageUrl = "Fresh-beeswax-for-hair-on-the-table.jpg"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Магнит",
                CategoryId = Guid.Parse("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                Price = 1.99,
                IsDiscounted = false,
                Description = "Изработен от издръжливи материали, той сигурно държи вашите бележки, снимки и списъци с покупки на място, като добавя искрица на личност на вратата на вашата хладилна витрина.",
                QuantityInStock = 100,
                ProductAmount = "Единичен артикул",
                TimesOrdered = 0,
                MainImageUrl = "BeeMagnet.jpg"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Чаша за кафе",
                CategoryId = Guid.Parse("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                Price = 2.99,
                IsDiscounted = false,
                Description = "Представяме ви керамична чаша с малки пчелички, добавяща допир на природа към вашето сутрешно ежедневие. Изработена с внимание, всяка пчела е ръчно рисувана за уникален и очарователен дизайн.",
                QuantityInStock = 50,
                ProductAmount = "Единичен артикул",
                TimesOrdered = 0,
                MainImageUrl = "coffee-cup-bees.jpg"
});
        }

    }
}