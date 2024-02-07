using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosialMediaProject.Data.Migrations
{
    public partial class IsStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Visibility",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }
    }
}
