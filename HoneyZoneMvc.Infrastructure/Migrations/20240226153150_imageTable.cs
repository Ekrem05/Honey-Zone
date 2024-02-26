using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Infrastructure.Migrations
{
    public partial class imageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageNames_Products_ProductId",
                table: "ImageNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageNames",
                table: "ImageNames");

            migrationBuilder.DropIndex(
                name: "IX_ImageNames_ProductId",
                table: "ImageNames");

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("7f58427a-0997-4d74-83dc-bbbd2568d7c0"));

            migrationBuilder.DeleteData(
                table: "DeliverMethods",
                keyColumn: "Id",
                keyValue: new Guid("fc734711-2a78-4628-99b7-8809f2b94d26"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b8db6e8-28a9-44d1-8a3b-cb0658849bd1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b61cb88-99f2-4d22-a624-00e72e2db7c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("91c8981a-e8ff-417c-b90c-f212a242016a"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("44006623-fd87-4000-88e8-3beadc082178"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a8d5ffd7-20de-49f2-801c-178224585b07"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("b8f5d2cf-56c8-490d-ba95-01839679ee21"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("e312c824-f87d-4ec5-961b-898ab289bbb4"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("f4299868-4e9c-4027-a612-045d0e94af2f"));

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ImageNames");

            migrationBuilder.RenameTable(
                name: "ImageNames",
                newName: "ImageUrls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageUrls",
                table: "ImageUrls",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageUrls",
                table: "ImageUrls");

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

            migrationBuilder.RenameTable(
                name: "ImageUrls",
                newName: "ImageNames");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ImageNames",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageNames",
                table: "ImageNames",
                column: "Id");

            migrationBuilder.InsertData(
                table: "DeliverMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7f58427a-0997-4d74-83dc-bbbd2568d7c0"), "Спиди" },
                    { new Guid("fc734711-2a78-4628-99b7-8809f2b94d26"), "Eконт" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "MainImageUrl", "Name", "Price", "ProductAmount", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("3b8db6e8-28a9-44d1-8a3b-cb0658849bd1"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Акациевият мед е светъл и благороден, със свеж и деликатен вкус. Произведен от цветята на акацията, този мед е изключително чист и прозрачен. Сладък аромат и лека консистенция правят акациевия мед предпочитан избор. Също така се цени за потенциалните му благоприятни върху здравето свойства, като антибактериални и противовъзпалителни ефекти. Възможно е да бъде употребяван самостоятелно или като добавка към различни ястия и напитки.", "attachment_86137655.jpg", "Акациев мед", 25.989999999999998, "1кг", 27 },
                    { new Guid("4b61cb88-99f2-4d22-a624-00e72e2db7c1"), new Guid("78355d47-6040-4676-9972-ac8be4f19882"), "Слънчогледовият мед е уникален продукт, получен от нектара на цветовете на слънчогледа. Този вид мед се отличава с лек, сладък вкус и ярко златист цвят. Ароматът му е нежен и приятен, с леки оттенъци на цветя. Слънчогледовият мед често се характеризира със средна до по-плътна консистенция и може да кристализира с времето, образувайки фини кристали. Този процес не влияе на качествата на меда и може бързо да се възстанови до течно състояние с леко загряване.", "bg honey2.png", "Слънчогледов мед", 19.989999999999998, "800г", 82 },
                    { new Guid("91c8981a-e8ff-417c-b90c-f212a242016a"), new Guid("c7d08da8-a5af-4596-8ad2-d0f99091297f"), "Горският прашец е пчелен продукт, събран от пчели в горите от различни дървесни видове. Той е плътен и карамелен по цвят, с интензивен аромат и сладък вкус. Горският прашец е известен със своите богати хранителни и лечебни свойства, като се счита за естествен източник на витамини, минерали и антиоксиданти. Често се използва като добавка към храна или напитки за подобряване на имунната система и засилване на енергията.", "bee-pollen-2549125_1280.jpg", "Горски прашец", 55.990000000000002, "2кг", 102 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("44006623-fd87-4000-88e8-3beadc082178"), "В обработка" },
                    { new Guid("a8d5ffd7-20de-49f2-801c-178224585b07"), "Получена" },
                    { new Guid("b8f5d2cf-56c8-490d-ba95-01839679ee21"), "Доставена" },
                    { new Guid("e312c824-f87d-4ec5-961b-898ab289bbb4"), "Отменена" },
                    { new Guid("f4299868-4e9c-4027-a612-045d0e94af2f"), "Изпратена" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageNames_ProductId",
                table: "ImageNames",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageNames_Products_ProductId",
                table: "ImageNames",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
