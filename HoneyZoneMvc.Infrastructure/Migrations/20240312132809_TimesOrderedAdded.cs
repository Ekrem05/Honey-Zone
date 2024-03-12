using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class TimesOrderedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("3f7c2af4-814d-4945-8898-b219fccf8bfb"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("6e2b7cc8-6780-4cc5-ae04-1a3263347fcc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("12d1cd6d-9846-4a0e-ba2a-17cfac257ace"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3defd2db-60a2-4f39-b15d-2ccb988d897b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a43bb1a-3c14-4775-a30f-6f035368a53a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("80cf7d27-3aab-421d-8baa-e2b26e0b3f87"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("afe39d76-7d20-47b7-8684-cf96cc73e993"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b499a437-222e-4b76-9bca-fb3a0dfc9c7d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e0d046d3-beb6-4c1b-926b-40834e802afe"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("2547f921-78b9-4433-b7fe-d04d12789681"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("58bd843f-89b0-4a9f-a2b6-360a8c8f3dd9"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("5de90af0-3a6a-40e4-a1db-20023c9b9eb7"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("62c058a1-e78b-4948-a2dc-23b7a45095b7"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("d15cacb7-ad0b-4a7e-a218-a882bef046c6"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3f7c2af4-814d-4945-8898-b219fccf8bfb"), "Спиди" },
                    { new Guid("6e2b7cc8-6780-4cc5-ae04-1a3263347fcc"), "Eконт" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("12d1cd6d-9846-4a0e-ba2a-17cfac257ace"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.", 20.0, true, "bg honey2.png", "Sunflower honey", 19.989999999999998, "800g", 82, 0 },
                    { new Guid("3defd2db-60a2-4f39-b15d-2ccb988d897b"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.", 0.0, false, "black bg honey.jpg", "Manuka Honey", 18.989999999999998, "1kg", 11, 0 },
                    { new Guid("5a43bb1a-3c14-4775-a30f-6f035368a53a"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.", 0.0, false, "26545.jpg", "Coffee Cup", 2.9900000000000002, "Single item", 50, 0 },
                    { new Guid("80cf7d27-3aab-421d-8baa-e2b26e0b3f87"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!", 0.0, false, "BeeMagnet.jpg", "Fridge Magnet", 1.99, "Single item", 100, 0 },
                    { new Guid("afe39d76-7d20-47b7-8684-cf96cc73e993"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Wildflower Pollen", 55.990000000000002, "2kg", 102, 0 },
                    { new Guid("b499a437-222e-4b76-9bca-fb3a0dfc9c7d"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Beeswax", 31.989999999999998, "900g", 202, 0 },
                    { new Guid("e0d046d3-beb6-4c1b-926b-40834e802afe"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.", 0.0, false, "attachment_86137655.jpg", "Acacia honey", 25.989999999999998, "1kg", 27, 0 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2547f921-78b9-4433-b7fe-d04d12789681"), "Доставена" },
                    { new Guid("58bd843f-89b0-4a9f-a2b6-360a8c8f3dd9"), "Отменена" },
                    { new Guid("5de90af0-3a6a-40e4-a1db-20023c9b9eb7"), "В обработка" },
                    { new Guid("62c058a1-e78b-4948-a2dc-23b7a45095b7"), "Получена" },
                    { new Guid("d15cacb7-ad0b-4a7e-a218-a882bef046c6"), "Изпратена" }
                });
        }
    }
}
