using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWall.Migrations
{
    public partial class fourthmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
