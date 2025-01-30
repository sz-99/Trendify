using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class replaceClothingswithClothingItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colour_Clothings_ClothingItemId",
                table: "Colour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clothings",
                table: "Clothings");

            migrationBuilder.RenameTable(
                name: "Clothings",
                newName: "ClothingItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingItems",
                table: "ClothingItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colour_ClothingItems_ClothingItemId",
                table: "Colour",
                column: "ClothingItemId",
                principalTable: "ClothingItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colour_ClothingItems_ClothingItemId",
                table: "Colour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingItems",
                table: "ClothingItems");

            migrationBuilder.RenameTable(
                name: "ClothingItems",
                newName: "Clothings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clothings",
                table: "Clothings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colour_Clothings_ClothingItemId",
                table: "Colour",
                column: "ClothingItemId",
                principalTable: "Clothings",
                principalColumn: "Id");
        }
    }
}
