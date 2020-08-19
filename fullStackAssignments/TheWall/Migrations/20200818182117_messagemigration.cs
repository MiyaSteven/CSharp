using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWall.Migrations
{
    public partial class messagemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Messages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Messages");
        }
    }
}
