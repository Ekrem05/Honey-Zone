﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class initialTimesOrdered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("101b9a09-31cf-4e31-bf83-7f1b2f822ec4"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("c88aad70-532c-4c63-9d76-21c54bacdf9d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a2f2eae-c736-494b-9824-9e24061ef847"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9031ed69-acd0-4962-ab62-391d90faa9a6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9133e1ee-9fcb-4bdf-88d4-f006e6a1b7d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d5d06df-37c9-4c2d-8b91-a0b1d56489cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a76bbcea-8529-4c50-a1ed-791dc2679167"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cab661eb-6842-4b6c-86f3-aaeb3bd4e42f"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("13c6f7fe-9731-4d1a-84d4-5087b002a55a"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("32ec3f05-55da-4f52-8e3d-613ec7aaaf11"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("3e970a75-9df1-4152-ac89-54d289a473a4"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("b5d57c5d-8fb5-4e8e-9cc2-757b30c95290"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("d68d4b68-3467-48ff-a5e9-c0b5d767fa3a"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
                column: "ConcurrencyStamp",
                value: "4b727f19-77f5-4983-8196-37fe17f7e89a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "886c448c-714e-48a5-997b-5fa5435df47f", "AQAAAAEAACcQAAAAEKKe0+QfgOGS7SilnDX+xIZPDXBOL81lVTyBzf5Xehz5KHZQ0eZebQJ2TsLgpwTWMw==", "B23CFEAE-2D8C-412A-A1CD-8649D680EF32" });

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("302ed305-6294-4ac6-820c-48d8304c4f8a"), "Speedy" },
                    { new Guid("9473a83c-7fdd-4a5d-808c-36830b69bf95"), "Econt" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                column: "TimesOrdered",
                value: 1);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("4d72e7de-5868-49ac-9bb9-279f73236f39"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.", 0.0, false, "coffee-cup-bees.jpg", "Coffee Cup", 2.9900000000000002, "Single item", 50, 0 },
                    { new Guid("7cdeb980-b1e1-4cb8-a779-6b4103b4ae1a"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.", 0.0, false, "black bg honey.png", "Manuka Honey", 18.989999999999998, "1kg", 11, 3 },
                    { new Guid("88a6821b-ff9d-4b9a-8ab7-4a967296bc13"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Wildflower Pollen", 55.990000000000002, "2kg", 102, 0 },
                    { new Guid("9577ce22-1266-4b40-b75d-bf0b83731f59"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.", 0.0, false, "attachment_86137655.jpg", "Acacia honey", 25.989999999999998, "1kg", 27, 2 },
                    { new Guid("c1c318da-fd69-4d0a-8a9a-944b1cf42a01"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Beeswax", 31.989999999999998, "900g", 202, 0 },
                    { new Guid("e8fe2e2b-2c8b-46b7-80fa-103161736cae"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!", 0.0, false, "BeeMagnet.jpg", "Fridge Magnet", 1.99, "Single item", 100, 0 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6df8f362-0d79-4498-aca2-dddaaee322e0"), "Pending" },
                    { new Guid("6e102dc8-d419-4cc5-bb4e-6adf3fa6c9db"), "Sent" },
                    { new Guid("b2ecae41-7528-4f89-8619-3d19b9e30f8b"), "Confirmed" },
                    { new Guid("b6111269-3d24-4c89-81da-5b5fa34a4f6d"), "Delivered" },
                    { new Guid("dc5dcf83-4169-4fa2-be67-4e9b524d5c02"), "Cancelled" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("302ed305-6294-4ac6-820c-48d8304c4f8a"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("9473a83c-7fdd-4a5d-808c-36830b69bf95"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d72e7de-5868-49ac-9bb9-279f73236f39"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cdeb980-b1e1-4cb8-a779-6b4103b4ae1a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("88a6821b-ff9d-4b9a-8ab7-4a967296bc13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9577ce22-1266-4b40-b75d-bf0b83731f59"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c1c318da-fd69-4d0a-8a9a-944b1cf42a01"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8fe2e2b-2c8b-46b7-80fa-103161736cae"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("6df8f362-0d79-4498-aca2-dddaaee322e0"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("6e102dc8-d419-4cc5-bb4e-6adf3fa6c9db"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("b2ecae41-7528-4f89-8619-3d19b9e30f8b"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("b6111269-3d24-4c89-81da-5b5fa34a4f6d"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("dc5dcf83-4169-4fa2-be67-4e9b524d5c02"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83e83014-e29a-4d0e-9238-b52cf68bf6b7"),
                column: "ConcurrencyStamp",
                value: "a594ebed-a099-47c3-94c2-83808060a89c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("10b051ec-ea4e-45a1-a02e-8c7fecab633f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "debc5e44-d93d-4f07-b572-a6ee9487647c", "AQAAAAEAACcQAAAAEBSj1Uj/D3rg+gH3MBixn0UH/nuJmDRqibNy3qSGLwETHyN04eFYtxlGe0gtBjemKg==", "4DAE8132-0A60-4C1E-850A-5F6BB99A6D0F" });

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("101b9a09-31cf-4e31-bf83-7f1b2f822ec4"), "Speedy" },
                    { new Guid("c88aad70-532c-4c63-9d76-21c54bacdf9d"), "Econt" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c7ecd019-40b1-47f3-89c4-67e3625f796b"),
                column: "TimesOrdered",
                value: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock", "TimesOrdered" },
                values: new object[,]
                {
                    { new Guid("0a2f2eae-c736-494b-9824-9e24061ef847"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Introducing our ceramic coffee cup adorned with small bees, adding a touch of nature to your morning routine. Crafted with care, each bee is hand-painted for a unique and charming design. Enjoy your favorite brew in style and bring the beauty of the outdoors to your daily cup of coffee.", 0.0, false, "coffee-cup-bees.jpg", "Coffee Cup", 2.9900000000000002, "Single item", 50, 0 },
                    { new Guid("9031ed69-acd0-4962-ab62-391d90faa9a6"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the exquisite taste and health benefits of Manuka Honey. Sourced from the pristine landscapes of New Zealand, this rare honey is renowned for its rich flavor and potent medicinal properties. With its unique antibacterial and antioxidant qualities, Manuka Honey offers a natural boost to your immune system and promotes overall wellness.", 0.0, false, "black bg honey.png", "Manuka Honey", 18.989999999999998, "1kg", 11, 0 },
                    { new Guid("9133e1ee-9fcb-4bdf-88d4-f006e6a1b7d9"), new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Made from durable materials, it securely holds your notes, photos, and grocery lists in place while adding a pop of personality to your fridge door. Bring a little bit of nature indoors and brighten up your kitchen with our Bee Fridge Magnet today!", 0.0, false, "BeeMagnet.jpg", "Fridge Magnet", 1.99, "Single item", 100, 0 },
                    { new Guid("9d5d06df-37c9-4c2d-8b91-a0b1d56489cf"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Indulge in the delicate sweetness of our Acacia honey. Sourced from the pristine blossoms of Acacia trees, this golden nectar boasts a subtle floral aroma and a smooth, light taste. Perfect for drizzling over yogurt, spreading on toast, or sweetening your favorite beverages. Treat yourself to the pure, exquisite flavor of Acacia honey today.", 0.0, false, "attachment_86137655.jpg", "Acacia honey", 25.989999999999998, "1kg", 27, 0 },
                    { new Guid("a76bbcea-8529-4c50-a1ed-791dc2679167"), new Guid("f4251d33-9582-4be6-8bea-be96dd30804e"), "Discover the versatile beauty of pure Beeswax. Known for its natural scent and golden hue, Beeswax is a versatile ingredient used in candles, skincare products, and more. Crafted by bees with precision, it offers a gentle, protective barrier for your skin and a warm, inviting glow when lit. Embrace the timeless elegance and natural charm of Beeswax in your daily rituals.", 10.0, true, "Fresh-beeswax-for-hair-on-the-table.jpg", "Beeswax", 31.989999999999998, "900g", 202, 0 },
                    { new Guid("cab661eb-6842-4b6c-86f3-aaeb3bd4e42f"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Discover the power of nature with our premium bee pollen product. Packed with nutrients and harvested from the finest sources, our bee pollen is a natural boost for your health and wellness routine. Simply sprinkle it on your favorite foods or blend it into smoothies for a delicious and nutritious addition. Energize your day the natural way with our bee pollen.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Wildflower Pollen", 55.990000000000002, "2kg", 102, 0 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13c6f7fe-9731-4d1a-84d4-5087b002a55a"), "Sent" },
                    { new Guid("32ec3f05-55da-4f52-8e3d-613ec7aaaf11"), "Cancelled" },
                    { new Guid("3e970a75-9df1-4152-ac89-54d289a473a4"), "Delivered" },
                    { new Guid("b5d57c5d-8fb5-4e8e-9cc2-757b30c95290"), "Confirmed" },
                    { new Guid("d68d4b68-3467-48ff-a5e9-c0b5d767fa3a"), "Pending" }
                });
        }
    }
}
