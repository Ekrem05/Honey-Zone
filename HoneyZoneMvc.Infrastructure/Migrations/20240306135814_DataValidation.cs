using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class DataValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Country",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "States",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "OrderDetail",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "OrderDetail",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "OrderDetail",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "OrderDetail",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "OrderDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "OrderDetail",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ImageUrls",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DeliverMethods",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e302594-d8b3-457d-808d-97ba9af89d92"), "Спиди" },
                    { new Guid("60c10e31-570b-4a36-9fb4-771f582c5ff5"), "Eконт" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsDiscounted", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("3a9c3b9d-56bf-4087-aa2c-20584dfaf935"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Горският прашец е пчелен продукт, събран от пчели в горите от различни дървесни видове. Той е плътен и карамелен по цвят, с интензивен аромат и сладък вкус. Горският прашец е известен със своите богати хранителни и лечебни свойства, като се счита за естествен източник на витамини, минерали и антиоксиданти. Често се използва като добавка към храна или напитки за подобряване на имунната система и засилване на енергията.", 55.0, true, "bee-pollen-2549125_1280.jpg", "Горски прашец", 55.990000000000002, "2кг", 102 },
                    { new Guid("79d4366f-399d-43c5-88e7-af25576416a8"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Слънчогледовият мед е уникален продукт, получен от нектара на цветовете на слънчогледа. Този вид мед се отличава с лек, сладък вкус и ярко златист цвят. Ароматът му е нежен и приятен, с леки оттенъци на цветя. Слънчогледовият мед често се характеризира със средна до по-плътна консистенция и може да кристализира с времето, образувайки фини кристали. Този процес не влияе на качествата на меда и може бързо да се възстанови до течно състояние с леко загряване.", 20.0, true, "bg honey2.png", "Слънчогледов мед", 19.989999999999998, "800г", 82 },
                    { new Guid("9fccb074-82db-4ad5-8aee-ceaf2fe00aaa"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Акациевият мед е светъл и благороден, със свеж и деликатен вкус. Произведен от цветята на акацията, този мед е изключително чист и прозрачен. Сладък аромат и лека консистенция правят акациевия мед предпочитан избор. Също така се цени за потенциалните му благоприятни върху здравето свойства, като антибактериални и противовъзпалителни ефекти. Възможно е да бъде употребяван самостоятелно или като добавка към различни ястия и напитки.", 0.0, false, "attachment_86137655.jpg", "Акациев мед", 25.989999999999998, "1кг", 27 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("398ea304-dd6c-4790-ae5b-2d13653e27ac"), "Изпратена" },
                    { new Guid("3aba8c2f-9d8f-479b-948a-812f5a500d83"), "В обработка" },
                    { new Guid("651080d1-0298-4c54-a7f6-d6dd648c78d2"), "Получена" },
                    { new Guid("f58cb890-6a72-41ce-889c-f7ab1f8d5173"), "Отменена" },
                    { new Guid("f912bb28-3607-423a-921b-59f3c9daeec3"), "Доставена" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("0e302594-d8b3-457d-808d-97ba9af89d92"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("60c10e31-570b-4a36-9fb4-771f582c5ff5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3a9c3b9d-56bf-4087-aa2c-20584dfaf935"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("79d4366f-399d-43c5-88e7-af25576416a8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fccb074-82db-4ad5-8aee-ceaf2fe00aaa"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("398ea304-dd6c-4790-ae5b-2d13653e27ac"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("3aba8c2f-9d8f-479b-948a-812f5a500d83"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("651080d1-0298-4c54-a7f6-d6dd648c78d2"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("f58cb890-6a72-41ce-889c-f7ab1f8d5173"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("f912bb28-3607-423a-921b-59f3c9daeec3"));

            migrationBuilder.DropColumn(
                name: "City",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "States",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ImageUrls",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DeliverMethods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

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
        }
    }
}
