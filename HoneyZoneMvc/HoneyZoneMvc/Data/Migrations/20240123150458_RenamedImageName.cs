using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoneyZoneMvc.Data.Migrations
{
    public partial class RenamedImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ImageUrls",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "ImageUrls",
                newName: "Url");
        }
    }
}
