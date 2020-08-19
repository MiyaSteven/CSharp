using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWall.Migrations
{
    public partial class homewrappermigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
