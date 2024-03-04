using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class ProductDiscountAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("4f724f14-e407-4c76-9980-63c62723679d"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("c642839d-aa59-4aa1-b682-3512b0ddbf0f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("03bb1620-7640-49d8-9461-d2de32d1eee5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("28c52b1a-1307-4311-9ff4-a3e10cb61363"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6fba38f4-6ea7-4fee-8df0-83a3aebde3d0"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("20c0fca3-0530-486d-9d73-bf880da03b7a"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("20c2b549-1ef0-4151-a650-93649d538e33"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("56b0b3ca-d2df-4058-8ff9-ada25060baa5"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("6f6c73d0-2442-4d3e-a367-37dd5dbfe1b0"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("f2dfcfbc-881d-4428-9bc9-b865381557b6"));

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Product Discounted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscounted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Has Discount Or Not");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12ec419b-886a-443c-bb4a-155f61cfaedd"), "Eконт" },
                    { new Guid("cdea3610-3443-4bd5-a2c9-f717342f665e"), "Спиди" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("4a097092-1105-49e7-93d5-e44f79ef7729"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Слънчогледовият мед е уникален продукт, получен от нектара на цветовете на слънчогледа. Този вид мед се отличава с лек, сладък вкус и ярко златист цвят. Ароматът му е нежен и приятен, с леки оттенъци на цветя. Слънчогледовият мед често се характеризира със средна до по-плътна консистенция и може да кристализира с времето, образувайки фини кристали. Този процес не влияе на качествата на меда и може бързо да се възстанови до течно състояние с леко загряване.", 20.0, true, "bg honey2.png", "Слънчогледов мед", 19.989999999999998, "800г", 82 },
                    { new Guid("bb78adb6-0ca0-4bf2-b138-09364c5af9cf"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Акациевият мед е светъл и благороден, със свеж и деликатен вкус. Произведен от цветята на акацията, този мед е изключително чист и прозрачен. Сладък аромат и лека консистенция правят акациевия мед предпочитан избор. Също така се цени за потенциалните му благоприятни върху здравето свойства, като антибактериални и противовъзпалителни ефекти. Възможно е да бъде употребяван самостоятелно или като добавка към различни ястия и напитки.", 0.0, false, "attachment_86137655.jpg", "Акациев мед", 25.989999999999998, "1кг", 27 },
                    { new Guid("c95b6155-beae-4a0e-b77f-361ad718590e"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Горският прашец е пчелен продукт, събран от пчели в горите от различни дървесни видове. Той е плътен и карамелен по цвят, с интензивен аромат и сладък вкус. Горският прашец е известен със своите богати хранителни и лечебни свойства, като се счита за естествен източник на витамини, минерали и антиоксиданти. Често се използва като добавка към храна или напитки за подобряване на имунната система и засилване на енергията.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Горски прашец", 55.990000000000002, "2кг", 102 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15d9ee27-40ff-49f1-b356-e466b44ea769"), "Доставена" },
                    { new Guid("457199f1-da7c-4ab8-9f94-0896da3d9b2b"), "Получена" },
                    { new Guid("54c0a53e-230d-4e68-b3cf-75a92295e7b4"), "В обработка" },
                    { new Guid("a4c4d6d2-c573-4f9d-af6e-61a0ca462f9d"), "Изпратена" },
                    { new Guid("c502e03d-af5c-429d-adb7-8bd259f0723e"), "Отменена" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("12ec419b-886a-443c-bb4a-155f61cfaedd"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("cdea3610-3443-4bd5-a2c9-f717342f665e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4a097092-1105-49e7-93d5-e44f79ef7729"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb78adb6-0ca0-4bf2-b138-09364c5af9cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c95b6155-beae-4a0e-b77f-361ad718590e"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("15d9ee27-40ff-49f1-b356-e466b44ea769"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("457199f1-da7c-4ab8-9f94-0896da3d9b2b"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("54c0a53e-230d-4e68-b3cf-75a92295e7b4"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a4c4d6d2-c573-4f9d-af6e-61a0ca462f9d"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("c502e03d-af5c-429d-adb7-8bd259f0723e"));

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDiscounted",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderProducts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4f724f14-e407-4c76-9980-63c62723679d"), "Eконт" },
                    { new Guid("c642839d-aa59-4aa1-b682-3512b0ddbf0f"), "Спиди" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("03bb1620-7640-49d8-9461-d2de32d1eee5"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Слънчогледовият мед е уникален продукт, получен от нектара на цветовете на слънчогледа. Този вид мед се отличава с лек, сладък вкус и ярко златист цвят. Ароматът му е нежен и приятен, с леки оттенъци на цветя. Слънчогледовият мед често се характеризира със средна до по-плътна консистенция и може да кристализира с времето, образувайки фини кристали. Този процес не влияе на качествата на меда и може бързо да се възстанови до течно състояние с леко загряване.", "bg honey2.png", "Слънчогледов мед", 19.989999999999998, "800г", 82 },
                    { new Guid("28c52b1a-1307-4311-9ff4-a3e10cb61363"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Горският прашец е пчелен продукт, събран от пчели в горите от различни дървесни видове. Той е плътен и карамелен по цвят, с интензивен аромат и сладък вкус. Горският прашец е известен със своите богати хранителни и лечебни свойства, като се счита за естествен източник на витамини, минерали и антиоксиданти. Често се използва като добавка към храна или напитки за подобряване на имунната система и засилване на енергията.", "bee-pollen-2549125_1280.jpg", "Горски прашец", 55.990000000000002, "2кг", 102 },
                    { new Guid("6fba38f4-6ea7-4fee-8df0-83a3aebde3d0"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Акациевият мед е светъл и благороден, със свеж и деликатен вкус. Произведен от цветята на акацията, този мед е изключително чист и прозрачен. Сладък аромат и лека консистенция правят акациевия мед предпочитан избор. Също така се цени за потенциалните му благоприятни върху здравето свойства, като антибактериални и противовъзпалителни ефекти. Възможно е да бъде употребяван самостоятелно или като добавка към различни ястия и напитки.", "attachment_86137655.jpg", "Акациев мед", 25.989999999999998, "1кг", 27 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("20c0fca3-0530-486d-9d73-bf880da03b7a"), "Изпратена" },
                    { new Guid("20c2b549-1ef0-4151-a650-93649d538e33"), "Отменена" },
                    { new Guid("56b0b3ca-d2df-4058-8ff9-ada25060baa5"), "Доставена" },
                    { new Guid("6f6c73d0-2442-4d3e-a367-37dd5dbfe1b0"), "Получена" },
                    { new Guid("f2dfcfbc-881d-4428-9bc9-b865381557b6"), "В обработка" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
