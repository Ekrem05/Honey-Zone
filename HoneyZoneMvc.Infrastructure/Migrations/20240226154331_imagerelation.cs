using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class imagerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("2a66ab48-6da7-4a1b-9082-9f1733524686"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("9fc47a47-8e5b-4356-9247-6e2f3e40ff4e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86e2f9f3-cfea-46fe-bd1a-dc6913d4fd16"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c11d6e7a-bf2a-4f30-ad2c-967712e68fb1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea57a797-3a01-4e50-906b-8e234cec4691"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("1b926745-9d0e-4dca-bd97-8786b1d490e2"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("818612c7-fee5-41c8-ad90-78cf09f8b067"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a666ba6b-6d11-42e5-b8dd-de77dd0bee45"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("b64ee04e-72ce-497f-a43a-e3fe0b79771e"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("bb978e80-5dc9-4510-8a10-8bf7da840132"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ImageUrls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_ImageUrls_ProductId",
                table: "ImageUrls",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUrls_Products_ProductId",
                table: "ImageUrls",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUrls_Products_ProductId",
                table: "ImageUrls");

            migrationBuilder.DropIndex(
                name: "IX_ImageUrls_ProductId",
                table: "ImageUrls");

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

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ImageUrls");

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a66ab48-6da7-4a1b-9082-9f1733524686"), "Спиди" },
                    { new Guid("9fc47a47-8e5b-4356-9247-6e2f3e40ff4e"), "Eконт" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("86e2f9f3-cfea-46fe-bd1a-dc6913d4fd16"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Слънчогледовият мед е уникален продукт, получен от нектара на цветовете на слънчогледа. Този вид мед се отличава с лек, сладък вкус и ярко златист цвят. Ароматът му е нежен и приятен, с леки оттенъци на цветя. Слънчогледовият мед често се характеризира със средна до по-плътна консистенция и може да кристализира с времето, образувайки фини кристали. Този процес не влияе на качествата на меда и може бързо да се възстанови до течно състояние с леко загряване.", "bg honey2.png", "Слънчогледов мед", 19.989999999999998, "800г", 82 },
                    { new Guid("c11d6e7a-bf2a-4f30-ad2c-967712e68fb1"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Горският прашец е пчелен продукт, събран от пчели в горите от различни дървесни видове. Той е плътен и карамелен по цвят, с интензивен аромат и сладък вкус. Горският прашец е известен със своите богати хранителни и лечебни свойства, като се счита за естествен източник на витамини, минерали и антиоксиданти. Често се използва като добавка към храна или напитки за подобряване на имунната система и засилване на енергията.", "bee-pollen-2549125_1280.jpg", "Горски прашец", 55.990000000000002, "2кг", 102 },
                    { new Guid("ea57a797-3a01-4e50-906b-8e234cec4691"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Акациевият мед е светъл и благороден, със свеж и деликатен вкус. Произведен от цветята на акацията, този мед е изключително чист и прозрачен. Сладък аромат и лека консистенция правят акациевия мед предпочитан избор. Също така се цени за потенциалните му благоприятни върху здравето свойства, като антибактериални и противовъзпалителни ефекти. Възможно е да бъде употребяван самостоятелно или като добавка към различни ястия и напитки.", "attachment_86137655.jpg", "Акациев мед", 25.989999999999998, "1кг", 27 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b926745-9d0e-4dca-bd97-8786b1d490e2"), "Отменена" },
                    { new Guid("818612c7-fee5-41c8-ad90-78cf09f8b067"), "Получена" },
                    { new Guid("a666ba6b-6d11-42e5-b8dd-de77dd0bee45"), "В обработка" },
                    { new Guid("b64ee04e-72ce-497f-a43a-e3fe0b79771e"), "Доставена" },
                    { new Guid("bb978e80-5dc9-4510-8a10-8bf7da840132"), "Изпратена" }
                });
        }
    }
}
