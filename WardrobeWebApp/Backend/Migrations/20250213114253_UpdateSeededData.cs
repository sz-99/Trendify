using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClothingItems",
                columns: new[] { "Id", "Brand", "Category", "Colour", "ImageId", "Name", "Occasion", "Season", "Size", "UserId" },
                values: new object[,]
                {
                    { 1, "Unknown", 8, "Black", 2, "Asymmetrical Black Skirt", 1, 1, 2, 1 },
                    { 2, "Wilfred", 5, "Blue", 3, "Blue Faux Leather Jacket", 2, 0, 3, 2 },
                    { 3, "M&S", 8, "Brown", 4, "Herringbone Bias-Cut Skirt", 2, 3, 2, 1 },
                    { 4, "& Other Stories", 0, "Dark Grey", 5, "Straight-Leg Grey Jeans", 3, 2, 2, 1 },
                    { 5, "Aritzia", 6, "Blue", 6, "Denim Corset Top w/ Back Zip", 6, 1, 2, 2 },
                    { 6, "Calvin Klein", 2, "Grey", 7, "Double-Breasted Coat w/ Belt and Button Stand Collar", 0, 3, 1, 2 },
                    { 7, "COS", 9, "Navy", 8, "Long-Sleeve Cotton Dungaree", 5, 2, 1, 2 },
                    { 8, "COS", 5, "Dark Grey", 9, "Cashmere V-Neck Cardigan", 6, 3, 3, 2 },
                    { 9, "The North Face", 2, "Black", 10, "Waterproof Coat w/ Removable Down Layer", 5, 3, 4, 2 },
                    { 10, "Wilfred", 3, "Light Blue", 11, "Off-The-Shoulder Crop Top", 6, 0, 1, 2 },
                    { 11, "Unknown", 1, "Black", 12, "Stripe Off-The-Shoulder Top", 1, 1, 2, 2 },
                    { 12, "Topshop", 0, "Dark Grey", 13, "High-Waisted Trousers w/ Matching Belt", 3, 2, 3, 2 },
                    { 13, "AllSaints", 4, "White", 14, "Cowl-Neck Slip Dress", 1, 1, 3, 2 },
                    { 14, "Uniqlo", 0, "White", 15, "Straight-Leg Knit Trousers w/ Elastic Waistband", 3, 0, 3, 2 },
                    { 15, "Y/Project", 5, "Black", 1, "Black Oversized Jumper", 3, 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "UserId", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "helloworld", "testuser1@wardrobe.com" },
                    { 2, "goodbyeworld", "testuser2@wardrobe.com" },
                    { 3, "hello", "testuser3@wardrobe.com" },
                    { 4, "password", "testuser4@wardrobe.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ClothingItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "UserId",
                keyValue: 4);
        }
    }
}
