using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class adminROleRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("1ff7062d-f7a9-4d06-be57-e2604f05649c"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("33f3d4a9-5299-440a-be8e-fcac88d5a83f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1a49709a-867a-44c8-a007-cc7d849d837a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("320edc42-7737-4c5a-b7fe-ef9e13f6a7a2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5a32c880-58f6-47ef-ad68-d41b3ddab27e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("726ec219-880c-401f-af6c-ef12560b68d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7efb80c5-1268-4db7-9dd5-d97f9535afc5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f3c5c84-0dea-4021-8349-3bb3db6606a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a97b181d-ebb9-43aa-a074-dd31a691c91b"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a1232c70-b6c0-4c6a-ad38-1b4cc703a63e"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("dfe120ea-b9df-4fa6-a176-1a163d4f38d4"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("f1fc29ae-44c2-4bcf-ab9a-05712ce64de6"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("fe374271-0272-4536-a893-131b36f4525a"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("ffc485a3-e9a3-4577-a2f3-5803e7879dba"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d88b7cd-1a8b-4879-81c5-9620fdf8451d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c98912ef-c052-4689-85eb-caf8ef49fd40", "AQAAAAEAACcQAAAAEORQhWYCFmjaJu38IK3EZERtBeh5H/pLaUEggPvWQwsiw51HP/h3STbJ974lJHcrOw==", "C8FCBFBC-2436-4CCA-8E51-1508F646856C" });

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("30a57e13-da8e-4237-8193-2fa392117781"), "Econt" },
                    { new Guid("7b72a44a-8551-4403-8e4f-21331c871052"), "Speedy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("09087007-c629-4557-9fb6-89e0a7cbd749"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.", 0.0, false, "attachment_86137655.jpg", "Acacia honey", 25.989999999999998, "1kg", 27, 0 },
                    { new Guid("3149a140-b99b-4ade-b506-13b02b2e95f0"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.", 0.0, false, "coffee-cup-bees.jpg", "Coffee Cup", 2.9900000000000002, "Single item", 50, 0 },
                    { new Guid("4ef1ad95-25bb-4067-96df-501edc0312bb"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!", 0.0, false, "BeeMagnet.jpg", "Fridge Magnet", 1.99, "Single item", 100, 0 },
                    { new Guid("7073fe9d-72ea-4d51-b1ac-b8a1c612c3cd"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Beeswax", 31.989999999999998, "900g", 202, 0 },
                    { new Guid("76cff94a-2e4f-4ceb-80e7-25756c088d3f"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.", 0.0, false, "black bg honey.png", "Manuka Honey", 18.989999999999998, "1kg", 11, 0 },
                    { new Guid("99def0eb-beb9-41ad-9ebb-474bd012cfec"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Wildflower Pollen", 55.990000000000002, "2kg", 102, 0 },
                    { new Guid("9dde1d9d-77d2-4254-bf26-71cfa42ea43b"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.", 20.0, true, "bg honey2.png", "Sunflower Honey", 19.989999999999998, "800g", 82, 0 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0bbe8121-9526-469b-8369-e71b2dbfcdaa"), "Pending" },
                    { new Guid("31ad6091-3a84-45b9-ac48-e65b18d8f658"), "Cancelled" },
                    { new Guid("80c276fe-bc40-42cd-a249-ef2e0f126de5"), "Confirmed" },
                    { new Guid("cadd0870-29b8-4e0e-a867-600a2f0ae59e"), "Sent" },
                    { new Guid("ebda945d-5cfb-4aec-a01c-c644e0c5fc5c"), "Delivered" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("30a57e13-da8e-4237-8193-2fa392117781"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("7b72a44a-8551-4403-8e4f-21331c871052"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09087007-c629-4557-9fb6-89e0a7cbd749"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3149a140-b99b-4ade-b506-13b02b2e95f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ef1ad95-25bb-4067-96df-501edc0312bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7073fe9d-72ea-4d51-b1ac-b8a1c612c3cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("76cff94a-2e4f-4ceb-80e7-25756c088d3f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99def0eb-beb9-41ad-9ebb-474bd012cfec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9dde1d9d-77d2-4254-bf26-71cfa42ea43b"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("0bbe8121-9526-469b-8369-e71b2dbfcdaa"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("31ad6091-3a84-45b9-ac48-e65b18d8f658"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("80c276fe-bc40-42cd-a249-ef2e0f126de5"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("cadd0870-29b8-4e0e-a867-600a2f0ae59e"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("ebda945d-5cfb-4aec-a01c-c644e0c5fc5c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e54db294-dc9e-489c-a32e-a470fe6b5ee3", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c135a84-8372-44c8-a772-3b1647a09690", "AQAAAAEAACcQAAAAECvb1MXI3Dn0yTbq5ZjpPnADpnnxeIzWpK/dYHM4xuSY7/Is+ZBy7A7+dKygVvXAkA==", "33FAF4AC-9656-4FCF-A773-D588D0A343A8" });

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1ff7062d-f7a9-4d06-be57-e2604f05649c"), "Econt" },
                    { new Guid("33f3d4a9-5299-440a-be8e-fcac88d5a83f"), "Speedy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("1a49709a-867a-44c8-a007-cc7d849d837a"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Savor the golden goodness of our Sunflower honey. With its rich, floral aroma and robust flavor, this honey is a true delight for your taste buds. Harvested from the vibrant blooms of sunflowers, it boasts a smooth texture and a hint of nutty sweetness. Perfect for adding a touch of sunshine to your morning tea or drizzling over freshly baked goods. Experience the pure taste of nature with our Sunflower honey.", 20.0, true, "bg honey2.png", "Sunflower Honey", 19.989999999999998, "800g", 82, 0 },
                    { new Guid("320edc42-7737-4c5a-b7fe-ef9e13f6a7a2"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.", 0.0, false, "attachment_86137655.jpg", "Acacia honey", 25.989999999999998, "1kg", 27, 0 },
                    { new Guid("5a32c880-58f6-47ef-ad68-d41b3ddab27e"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Wildflower Pollen", 55.990000000000002, "2kg", 102, 0 },
                    { new Guid("726ec219-880c-401f-af6c-ef12560b68d3"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!", 0.0, false, "BeeMagnet.jpg", "Fridge Magnet", 1.99, "Single item", 100, 0 },
                    { new Guid("7efb80c5-1268-4db7-9dd5-d97f9535afc5"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.", 0.0, false, "coffee-cup-bees.jpg", "Coffee Cup", 2.9900000000000002, "Single item", 50, 0 },
                    { new Guid("9f3c5c84-0dea-4021-8349-3bb3db6606a4"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.", 0.0, false, "black bg honey.png", "Manuka Honey", 18.989999999999998, "1kg", 11, 0 },
                    { new Guid("a97b181d-ebb9-43aa-a074-dd31a691c91b"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Beeswax", 31.989999999999998, "900g", 202, 0 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1232c70-b6c0-4c6a-ad38-1b4cc703a63e"), "Pending" },
                    { new Guid("dfe120ea-b9df-4fa6-a176-1a163d4f38d4"), "Cancelled" },
                    { new Guid("f1fc29ae-44c2-4bcf-ab9a-05712ce64de6"), "Sent" },
                    { new Guid("fe374271-0272-4536-a893-131b36f4525a"), "Delivered" },
                    { new Guid("ffc485a3-e9a3-4577-a2f3-5803e7879dba"), "Confirmed" }
                });
        }
    }
}
