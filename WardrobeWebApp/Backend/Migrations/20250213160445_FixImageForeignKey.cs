using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixImageForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageUrls",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUrls", x => x.ImageId);
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "ImageId", "Url" },
                values: new object[,]
                {
                    { 1, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/BlackJumper.jpg.jpg" },
                    { 2, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/blackSkirt.jpg.jpg" },
                    { 3, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/BlueJacket.jpg.jpg" },
                    { 4, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/BrownSkirt.jpg.jpg" },
                    { 5, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DarkGreyJeans.jpg.jpg" },
                    { 6, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 7, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 8, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 9, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 10, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 11, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 12, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 13, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 14, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" },
                    { 15, "https://wadrobe-images.s3.eu-west-2.amazonaws.com/DenimTop.jpg.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingItems_ImageId",
                table: "ClothingItems",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingItems_ImageUrls_ImageId",
                table: "ClothingItems",
                column: "ImageId",
                principalTable: "ImageUrls",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothingItems_ImageUrls_ImageId",
                table: "ClothingItems");

            migrationBuilder.DropTable(
                name: "ImageUrls");

            migrationBuilder.DropIndex(
                name: "IX_ClothingItems_ImageId",
                table: "ClothingItems");
        }
    }
}
