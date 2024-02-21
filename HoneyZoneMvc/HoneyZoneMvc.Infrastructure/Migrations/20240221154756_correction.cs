using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ClientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliverMethods_DeliveryMethodId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderDetail_OrderDetailId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_States_StateId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
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

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_StateId",
                table: "Orders",
                newName: "IX_Orders_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderDetailId",
                table: "Orders",
                newName: "IX_Orders_OrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DeliveryMethodId",
                table: "Orders",
                newName: "IX_Orders_DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientId",
                table: "Orders",
                newName: "IX_Orders_ClientId");

            migrationBuilder.AlterColumn<double>(
                name: "TotalSum",
                table: "Orders",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Сувенири" },
                    { new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Прашец" },
                    { new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"), "Мед" }
                });

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("94e4b658-7955-48bb-a851-03ecb97163fd"), "Сувенири" },
                    { new Guid("bb16f6ae-90ce-464b-9d03-495e2fdee0b6"), "Спиди" },
                    { new Guid("d0edf55a-b9ce-4847-a04f-e084e1948f7a"), "Eконт" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5d0ac772-6050-4564-93f3-f355d5cc57e4"), "Изпратена" },
                    { new Guid("684c9b34-9646-4053-b871-651f59065da8"), "Отменена" },
                    { new Guid("6db2d05f-6b20-4d14-8d38-53058a5ad1af"), "Получена" },
                    { new Guid("d43d8b64-7474-4765-9e61-3776147dbc32"), "Доставена" },
                    { new Guid("f9eb7f5e-5125-4542-9a60-544a52a3d157"), "В обработка" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliverMethods_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId",
                principalTable: "DeliverMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDetail_OrderDetailId",
                table: "Orders",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_States_StateId",
                table: "Orders",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliverMethods_DeliveryMethodId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDetail_OrderDetailId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_States_StateId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78355d47-6040-4676-9972-ac8be4f19882"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eb2aecdd-7815-49aa-973b-ee3173760fc5"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("94e4b658-7955-48bb-a851-03ecb97163fd"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("bb16f6ae-90ce-464b-9d03-495e2fdee0b6"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("d0edf55a-b9ce-4847-a04f-e084e1948f7a"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("5d0ac772-6050-4564-93f3-f355d5cc57e4"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("684c9b34-9646-4053-b871-651f59065da8"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("6db2d05f-6b20-4d14-8d38-53058a5ad1af"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("d43d8b64-7474-4765-9e61-3776147dbc32"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("f9eb7f5e-5125-4542-9a60-544a52a3d157"));

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StateId",
                table: "Order",
                newName: "IX_Order_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderDetailId",
                table: "Order",
                newName: "IX_Order_OrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Order",
                newName: "IX_Order_DeliveryMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientId",
                table: "Order",
                newName: "IX_Order_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "TotalSum",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ClientId",
                table: "Order",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliverMethods_DeliveryMethodId",
                table: "Order",
                column: "DeliveryMethodId",
                principalTable: "DeliverMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderDetail_OrderDetailId",
                table: "Order",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_States_StateId",
                table: "Order",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
