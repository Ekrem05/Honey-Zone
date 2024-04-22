using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class BgValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("37a420b3-6fd5-4922-a741-4298583813af"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("fbf795c2-7516-4fd9-9979-c44bab57858c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("29d58e82-afc0-4433-9794-526ad44e6976"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d4c94dc-fe3a-46f0-b1c5-3c35048e959a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7ca61d2a-a232-4d85-94a1-518c17b3d849"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4cccfd9-7b25-44fe-a785-1c0b286e0bff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db09dc54-9636-4fd8-a6dd-fee9edfd739c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb35088a-2a15-40d8-9207-0596b3c2cf99"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("aa54a723-dd2c-4232-bee5-7be89494f178"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("caa61a04-b961-4aa5-9851-1226ebeea072"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("ccfce986-e38a-4c30-b8b0-af4e50c1f931"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("efdf191d-7ffb-4c7c-a917-ec030a7cba2a"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("ff2ccc15-cb3c-42ed-93e2-b6d8ac8e6946"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
                column: "ConcurrencyStamp",
                value: "29bdab41-c409-4a8d-bd42-4d204566ca89");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f308cbc2-e3ac-42cc-b041-978a309d49b5", "AQAAAAEAACcQAAAAELt+4pSmqmiUY1fBTmGXe3DT3kL0KOnRk0eiO/oFgLgyV33EPafuzWOy3wvHIC+iuQ==", "C138A9DB-F65A-48E5-BAEC-BF07ECF56E08" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                column: "Name",
                value: "Мед");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                column: "Name",
                value: "Прашец");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                column: "Name",
                value: "Сувенири");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"),
                column: "Name",
                value: "Восък");

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00ee9595-1c69-424b-85b0-e1ed0d036a47"), "Econt" },
                    { new Guid("3e0b4246-717e-4527-b11f-6891b7292f4a"), "Speedy" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Насладете се на златистистият вкус на нашия слънчогледов мед. С богатия си, цветен аромат и силен вкус, този мед е истинско удоволствие. Събран от живите цветя на слънчогледите, той се отличава с гладка текстура и леко орехов сладникав вкус. Идеален за добавяне на допир от слънце към вашето сутрешно чайче или за поръсване върху свежо изпечени изделия. Преживейте чистия вкус на природата с нашия слънчогледов мед.", "Слънчогледов мед" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("1886cc74-89ae-4115-a907-2cfafdb730c5"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Открийте силата на природата с нашия премиум продукт от пчелен прашец. Пълен с хранителни вещества и събран от най-добрите източници, нашият пчелен прашец е естествено стимулиращ за здравето ви и рутината за благополучие. Просто поръсете го върху любимите си храни или го смесете в смутита за вкусно и хранително допълнение. Дайте енергия на деня си по естествен начин с нашия пчелен прашец.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Пчелен прашец", 55.990000000000002, "2kg", 102, 0 },
                    { new Guid("429c5420-2a3d-4c5e-ae7f-a0f2cb0fd90a"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Открийте универсалната красота на чистия пчелен восък. Известен с естествения си аромат и златист цвят, пчелният восък е универсална съставка, използвана в свещи, козметични продукти и други. Създаден от пчели с прецизност, той предлага нежна, защитна бариера за кожата ви и топъл, пригласителен блясък, когато се запали. Прегърнете вечната елегантност и естествената привлекателност на пчелния восък в ежедневните си ритуали.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Пчелен восък", 31.989999999999998, "900g", 202, 0 },
                    { new Guid("51207a00-f1f1-47de-acd4-b311125f060f"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Акациевият мед е светъл, почти безцветен и прозрачен, с лек аромат на цветя. Има фина текстура и деликатен вкус, който може да варира от леко сладък до умерено сладък в зависимост от източника на нектар. Често се използва в готвенето и печенето поради естествената си сладост и мек вкус.", 0.0, false, "attachment_86137655.jpg", "Акациев мед", 25.989999999999998, "1kg", 27, 2 },
                    { new Guid("5b9559cd-937a-4452-8495-cdf80fae8be2"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Представяме ви керамична чаша с малки пчелички, добавяща допир на природа към вашето сутрешно ежедневие. Изработена с внимание, всяка пчела е ръчно рисувана за уникален и очарователен дизайн.", 0.0, false, "coffee-cup-bees.jpg", "Чаша за кафе", 2.9900000000000002, "Единичен артикул", 50, 0 },
                    { new Guid("c5483175-1d79-4c5b-88fc-f32d7a5acea7"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Потопете се в изискания вкус и ползите за здравето на мановият мед. Произведен от чистите пейзажи на Нова Зеландия, този рядък мед е известен с богатия си вкус и мощните си лечебни свойства. Със своите уникални антибактериални и антиоксидантни качества, медът Манука предлага естествено стимулиране на имунната ви система и стимулира общото ви благополучие.", 0.0, false, "black bg honey.png", "Манов мед", 18.989999999999998, "1kg", 11, 3 },
                    { new Guid("ea22a3f5-d5bc-432b-b7b0-e06e8e5db562"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Изработен от издръжливи материали, той сигурно държи вашите бележки, снимки и списъци с покупки на място, като добавя искрица на личност на вратата на вашата хладилна витрина.", 0.0, false, "BeeMagnet.jpg", "Магнит за хладилник", 1.99, "Единичен артикул", 100, 0 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17c9ccc3-e047-424c-bcfd-d4942f8d8bad"), "Confirmed" },
                    { new Guid("289dc024-0555-4c6e-b5e5-bf5ab9592f94"), "Sent" },
                    { new Guid("2ceae410-c679-4c8e-867f-448be043dd6c"), "Pending" },
                    { new Guid("d1f0fcab-ac60-4848-8cb0-d2b0fe23b01c"), "Cancelled" },
                    { new Guid("f387dc04-13dc-4211-9c54-ff44e2910984"), "Delivered" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("00ee9595-1c69-424b-85b0-e1ed0d036a47"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("3e0b4246-717e-4527-b11f-6891b7292f4a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1886cc74-89ae-4115-a907-2cfafdb730c5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("429c5420-2a3d-4c5e-ae7f-a0f2cb0fd90a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("51207a00-f1f1-47de-acd4-b311125f060f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5b9559cd-937a-4452-8495-cdf80fae8be2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c5483175-1d79-4c5b-88fc-f32d7a5acea7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea22a3f5-d5bc-432b-b7b0-e06e8e5db562"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("17c9ccc3-e047-424c-bcfd-d4942f8d8bad"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("289dc024-0555-4c6e-b5e5-bf5ab9592f94"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("2ceae410-c679-4c8e-867f-448be043dd6c"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("d1f0fcab-ac60-4848-8cb0-d2b0fe23b01c"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("f387dc04-13dc-4211-9c54-ff44e2910984"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
                column: "ConcurrencyStamp",
                value: "e57840fd-1e5e-4e74-abaf-0f024d679d6b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36a51ff6-4883-4ecb-a05b-925c8cde19de", "AQAAAAEAACcQAAAAEDZtWFhj2eSAp9khqjH7vCVd88FUrLoAHyBbXWl/6w6UEw3YVmM99tHoPN0XOkqjlg==", "BC48566F-9B56-44DB-A108-9851E717099C" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78355d47-6040-4676-9972-ac8be4f19882"),
                column: "Name",
                value: "Honey");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"),
                column: "Name",
                value: "Bee Pollen");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"),
                column: "Name",
                value: "Мerchandise");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"),
                column: "Name",
                value: "Beeswax");

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("37a420b3-6fd5-4922-a741-4298583813af"), "Econt" },
                    { new Guid("fbf795c2-7516-4fd9-9979-c44bab57858c"), "Speedy" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.", "Sunflower Honey" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("29d58e82-afc0-4433-9794-526ad44e6976"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.", 0.0, false, "attachment_86137655.jpg", "Acacia honey", 25.989999999999998, "1kg", 27, 2 },
                    { new Guid("4d4c94dc-fe3a-46f0-b1c5-3c35048e959a"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.", 0.0, false, "coffee-cup-bees.jpg", "Coffee Cup", 2.9900000000000002, "Single item", 50, 0 },
                    { new Guid("7ca61d2a-a232-4d85-94a1-518c17b3d849"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.", 0.0, false, "black bg honey.png", "Manuka Honey", 18.989999999999998, "1kg", 11, 3 },
                    { new Guid("b4cccfd9-7b25-44fe-a785-1c0b286e0bff"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Wildflower Pollen", 55.990000000000002, "2kg", 102, 0 },
                    { new Guid("db09dc54-9636-4fd8-a6dd-fee9edfd739c"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Beeswax", 31.989999999999998, "900g", 202, 0 },
                    { new Guid("fb35088a-2a15-40d8-9207-0596b3c2cf99"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!", 0.0, false, "BeeMagnet.jpg", "Fridge Magnet", 1.99, "Single item", 100, 0 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aa54a723-dd2c-4232-bee5-7be89494f178"), "Confirmed" },
                    { new Guid("caa61a04-b961-4aa5-9851-1226ebeea072"), "Cancelled" },
                    { new Guid("ccfce986-e38a-4c30-b8b0-af4e50c1f931"), "Sent" },
                    { new Guid("efdf191d-7ffb-4c7c-a917-ec030a7cba2a"), "Pending" },
                    { new Guid("ff2ccc15-cb3c-42ed-93e2-b6d8ac8e6946"), "Delivered" }
                });
        }
    }
}
