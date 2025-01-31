using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class replaceColourswithColour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colour_ClothingItems_ClothingItemId",
                table: "Colour");

            migrationBuilder.DropIndex(
                name: "IX_Colour_ClothingItemId",
                table: "Colour");

            migrationBuilder.DropColumn(
                name: "ClothingItemId",
                table: "Colour");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "ClothingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "ClothingItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "ClothingItems");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "ClothingItems");

            migrationBuilder.AddColumn<int>(
                name: "ClothingItemId",
                table: "Colour",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colour_ClothingItemId",
                table: "Colour",
                column: "ClothingItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colour_ClothingItems_ClothingItemId",
                table: "Colour",
                column: "ClothingItemId",
                principalTable: "ClothingItems",
                principalColumn: "Id");
        }
    }
}
