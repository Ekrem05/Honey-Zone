using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class NamesTranslated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("3fc22d5a-59ce-4f5e-8133-ef692c3b4ad9"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("c89c93bb-86c9-4459-b387-3308b00f290c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b2bf1ff-0a42-465c-a51f-5a8f88fce343"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("78e3952e-9423-4b4a-8a32-82fedf38c150"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("adbc0d7e-405f-4cc1-a723-784cfa2e2977"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c09045ca-2932-4c15-87cb-6859c38de268"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e51206c3-7a01-4e4e-a5ef-eaf9bfebca5f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ebc70ebb-1311-420e-a6dd-57a537d29ddd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f46dc869-d498-4278-9e0e-614092b182d4"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("7163690d-988e-46b9-8f2f-3633d62b82c5"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("753aef04-ccf5-4d70-9205-03bea9988282"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("771794d7-10f6-46db-b021-563f60632c90"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("8c15d860-6411-446c-b99f-e114c3f252d5"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("d49cc193-bf69-43ec-856d-307d1a57f090"));

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
                    { new Guid("5d0df403-cbf4-4c25-ac0c-62b9021122a1"), "Econt" },
                    { new Guid("c23cb100-3aca-48ae-9d70-a4cda6faa68c"), "Speedy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("497aea16-ab27-4e76-b9e0-61726708bc6a"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.", 0.0, false, "coffee-cup-bees.jpg", "Coffee Cup", 2.9900000000000002, "Single item", 50, 0 },
                    { new Guid("7eac06be-de9c-4c0d-afe0-4997ee850978"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Beeswax", 31.989999999999998, "900g", 202, 0 },
                    { new Guid("84484046-a13b-42c5-bee2-40e401322d3b"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Wildflower Pollen", 55.990000000000002, "2kg", 102, 0 },
                    { new Guid("abc1cdf0-6412-439a-ade4-21fbc6cbe4c2"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.", 0.0, false, "attachment_86137655.jpg", "Acacia honey", 25.989999999999998, "1kg", 27, 0 },
                    { new Guid("c74bc044-9ec8-4f9b-b829-9de4b04f07cf"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.", 20.0, true, "bg honey2.png", "Sunflower honey", 19.989999999999998, "800g", 82, 0 },
                    { new Guid("d4d9eff0-a62f-4c86-a433-9c857dc71e02"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!", 0.0, false, "BeeMagnet.jpg", "Fridge Magnet", 1.99, "Single item", 100, 0 },
                    { new Guid("e42149a8-51e6-4a16-843d-f94e7de1cdc6"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.", 0.0, false, "black bg honey.png", "Manuka Honey", 18.989999999999998, "1kg", 11, 0 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15107515-7785-424a-90f4-4588dabe5c6f"), "Confirmed" },
                    { new Guid("1e289f24-10fe-43b8-bd08-3b0bb1c783f1"), "Cancelled" },
                    { new Guid("2fd2b441-ea4b-46c9-af1e-3c78ec03c4cf"), "Pending" },
                    { new Guid("3eb1024d-b32e-4f30-9651-1c7d43c850f7"), "Sent" },
                    { new Guid("675c84fa-b275-4531-87ea-c8210a6145d9"), "Delivered" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("5d0df403-cbf4-4c25-ac0c-62b9021122a1"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("c23cb100-3aca-48ae-9d70-a4cda6faa68c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("497aea16-ab27-4e76-b9e0-61726708bc6a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7eac06be-de9c-4c0d-afe0-4997ee850978"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84484046-a13b-42c5-bee2-40e401322d3b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("abc1cdf0-6412-439a-ade4-21fbc6cbe4c2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c74bc044-9ec8-4f9b-b829-9de4b04f07cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4d9eff0-a62f-4c86-a433-9c857dc71e02"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e42149a8-51e6-4a16-843d-f94e7de1cdc6"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("15107515-7785-424a-90f4-4588dabe5c6f"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("1e289f24-10fe-43b8-bd08-3b0bb1c783f1"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("2fd2b441-ea4b-46c9-af1e-3c78ec03c4cf"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("3eb1024d-b32e-4f30-9651-1c7d43c850f7"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("675c84fa-b275-4531-87ea-c8210a6145d9"));

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
                    { new Guid("3fc22d5a-59ce-4f5e-8133-ef692c3b4ad9"), "Eконт" },
                    { new Guid("c89c93bb-86c9-4459-b387-3308b00f290c"), "Спиди" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("4b2bf1ff-0a42-465c-a51f-5a8f88fce343"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.", 0.0, false, "attachment_86137655.jpg", "Acacia honey", 25.989999999999998, "1kg", 27, 0 },
                    { new Guid("78e3952e-9423-4b4a-8a32-82fedf38c150"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!", 0.0, false, "BeeMagnet.jpg", "Fridge Magnet", 1.99, "Single item", 100, 0 },
                    { new Guid("adbc0d7e-405f-4cc1-a723-784cfa2e2977"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.", 0.0, false, "black bg honey.png", "Manuka Honey", 18.989999999999998, "1kg", 11, 0 },
                    { new Guid("c09045ca-2932-4c15-87cb-6859c38de268"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.", 0.0, false, "coffee-cup-bees.jpg", "Coffee Cup", 2.9900000000000002, "Single item", 50, 0 },
                    { new Guid("e51206c3-7a01-4e4e-a5ef-eaf9bfebca5f"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.", 20.0, true, "bg honey2.png", "Sunflower honey", 19.989999999999998, "800g", 82, 0 },
                    { new Guid("ebc70ebb-1311-420e-a6dd-57a537d29ddd"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Wildflower Pollen", 55.990000000000002, "2kg", 102, 0 },
                    { new Guid("f46dc869-d498-4278-9e0e-614092b182d4"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Beeswax", 31.989999999999998, "900g", 202, 0 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7163690d-988e-46b9-8f2f-3633d62b82c5"), "Доставена" },
                    { new Guid("753aef04-ccf5-4d70-9205-03bea9988282"), "В обработка" },
                    { new Guid("771794d7-10f6-46db-b021-563f60632c90"), "Получена" },
                    { new Guid("8c15d860-6411-446c-b99f-e114c3f252d5"), "Изпратена" },
                    { new Guid("d49cc193-bf69-43ec-856d-307d1a57f090"), "Отменена" }
                });
        }
    }
}
