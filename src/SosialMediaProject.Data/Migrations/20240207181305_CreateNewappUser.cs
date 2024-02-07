using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SosialMediaProject.Data.Migrations
{
    public partial class CreateNewappUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisteredDate",
                table: "AspNetUsers");
        }
    }
}
