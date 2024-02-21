using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class seedDeliveries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("162fdd66-1ad2-436c-8b22-82ff109eeb8b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4e3b473f-d0b5-435a-9ae7-37a48d7d25a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c6fbb2c4-92ac-484c-a05a-7a434b4082a1"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("1ea5dcbc-ca92-4275-b1f6-8090be75721a"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("96988d66-70c2-40fe-89aa-cacc2b4a89bd"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a5160ae9-5a51-44d6-abeb-d4e3bc5263bd"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("b49a3c36-04d8-4ca2-8981-8f63aee843c8"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("d41a757f-bccc-424a-b32c-3f62ea829285"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3d9deb38-5203-4b29-be02-332bf497ebc0"), "Прашец" },
                    { new Guid("83e1006f-8d9e-44f1-945f-2908f2532f49"), "Сувенири" },
                    { new Guid("ce8678cf-d08a-4a1d-ad3c-1e73902234a0"), "Мед" }
                });

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f2bd25d-9328-410f-845e-00b1dcce3bef"), "Eконт" },
                    { new Guid("145c8884-20ef-4916-b146-339a137d08cd"), "Спиди" },
                    { new Guid("58b076ef-ff56-40f8-83c7-98adb4e16b7d"), "Сувенири" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f20d535-9299-4264-b991-30fbc018ed1d"), "Отменена" },
                    { new Guid("7fe45c89-296e-4b12-8224-32262d577a90"), "Изпратена" },
                    { new Guid("95d9d4ec-b4d3-460a-9dd3-0ab0ac395690"), "Доставена" },
                    { new Guid("9a13cbac-6f81-4451-8edd-fb08fbbef032"), "В обработка" },
                    { new Guid("c1a46828-6506-441a-8d51-5e479f93f808"), "Получена" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderDetailId",
                table: "Order",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderDetail_OrderDetailId",
                table: "Order",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderDetail_OrderDetailId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderDetailId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3d9deb38-5203-4b29-be02-332bf497ebc0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83e1006f-8d9e-44f1-945f-2908f2532f49"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce8678cf-d08a-4a1d-ad3c-1e73902234a0"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("0f2bd25d-9328-410f-845e-00b1dcce3bef"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("145c8884-20ef-4916-b146-339a137d08cd"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("58b076ef-ff56-40f8-83c7-98adb4e16b7d"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("0f20d535-9299-4264-b991-30fbc018ed1d"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("7fe45c89-296e-4b12-8224-32262d577a90"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("95d9d4ec-b4d3-460a-9dd3-0ab0ac395690"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("9a13cbac-6f81-4451-8edd-fb08fbbef032"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("c1a46828-6506-441a-8d51-5e479f93f808"));

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Order");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("162fdd66-1ad2-436c-8b22-82ff109eeb8b"), "Сувенири" },
                    { new Guid("4e3b473f-d0b5-435a-9ae7-37a48d7d25a8"), "Мед" },
                    { new Guid("c6fbb2c4-92ac-484c-a05a-7a434b4082a1"), "Прашец" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1ea5dcbc-ca92-4275-b1f6-8090be75721a"), "Доставена" },
                    { new Guid("96988d66-70c2-40fe-89aa-cacc2b4a89bd"), "Отменена" },
                    { new Guid("a5160ae9-5a51-44d6-abeb-d4e3bc5263bd"), "В обработка" },
                    { new Guid("b49a3c36-04d8-4ca2-8981-8f63aee843c8"), "Изпратена" },
                    { new Guid("d41a757f-bccc-424a-b32c-3f62ea829285"), "Получена" }
                });
        }
    }
}
