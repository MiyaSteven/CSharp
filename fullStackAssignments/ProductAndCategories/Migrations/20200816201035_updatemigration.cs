using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAndCategories.Migrations
{
    public partial class updatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAssociations_Categories_CategoryId",
                table: "CategoryAssociations");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAssociations_Products_ProductId",
                table: "CategoryAssociations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAssociations",
                table: "CategoryAssociations");

            migrationBuilder.RenameTable(
                name: "CategoryAssociations",
                newName: "Associations");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAssociations_ProductId",
                table: "Associations",
                newName: "IX_Associations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAssociations_CategoryId",
                table: "Associations",
                newName: "IX_Associations_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associations",
                table: "Associations",
                column: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Categories_CategoryId",
                table: "Associations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Products_ProductId",
                table: "Associations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Categories_CategoryId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Products_ProductId",
                table: "Associations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associations",
                table: "Associations");

            migrationBuilder.RenameTable(
                name: "Associations",
                newName: "CategoryAssociations");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_ProductId",
                table: "CategoryAssociations",
                newName: "IX_CategoryAssociations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_CategoryId",
                table: "CategoryAssociations",
                newName: "IX_CategoryAssociations_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAssociations",
                table: "CategoryAssociations",
                column: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAssociations_Categories_CategoryId",
                table: "CategoryAssociations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAssociations_Products_ProductId",
                table: "CategoryAssociations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
