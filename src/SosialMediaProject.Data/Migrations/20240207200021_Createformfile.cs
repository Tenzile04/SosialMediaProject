using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosialMediaProject.Data.Migrations
{
    public partial class Createformfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Posts",
                newName: "FormUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormUrl",
                table: "Posts",
                newName: "VideoUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
