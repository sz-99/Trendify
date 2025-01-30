using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class replacecolorwithcolour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavouriteColours",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Colours",
                table: "Clothings");

            migrationBuilder.CreateTable(
                name: "Colour",
                columns: table => new
                {
                    ColourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R = table.Column<byte>(type: "tinyint", nullable: false),
                    G = table.Column<byte>(type: "tinyint", nullable: false),
                    B = table.Column<byte>(type: "tinyint", nullable: false),
                    A = table.Column<byte>(type: "tinyint", nullable: false),
                    ClothingItemId = table.Column<int>(type: "int", nullable: true),
                    UserProfileUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colour", x => x.ColourId);
                    table.ForeignKey(
                        name: "FK_Colour_Clothings_ClothingItemId",
                        column: x => x.ClothingItemId,
                        principalTable: "Clothings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Colour_Profiles_UserProfileUserId",
                        column: x => x.UserProfileUserId,
                        principalTable: "Profiles",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colour_ClothingItemId",
                table: "Colour",
                column: "ClothingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Colour_UserProfileUserId",
                table: "Colour",
                column: "UserProfileUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colour");

            migrationBuilder.AddColumn<string>(
                name: "FavouriteColours",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Colours",
                table: "Clothings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
