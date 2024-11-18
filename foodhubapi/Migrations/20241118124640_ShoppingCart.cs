using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace foodhubapi.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af1a8e3d-8aed-440e-8e4a-1323d4fb9d8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c35b151f-e2a9-483f-a367-bafdfddee1d1");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    FoodMenuId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => new { x.FoodMenuId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_FoodMenus_FoodMenuId",
                        column: x => x.FoodMenuId,
                        principalTable: "FoodMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9732bb15-d3a0-4cc6-a02d-ec672ff22e93", null, "User", "USER" },
                    { "d3d21421-2bdb-4eba-a831-1c2f1b5d053b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AppUserId",
                table: "ShoppingCarts",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9732bb15-d3a0-4cc6-a02d-ec672ff22e93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3d21421-2bdb-4eba-a831-1c2f1b5d053b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "af1a8e3d-8aed-440e-8e4a-1323d4fb9d8c", null, "User", "USER" },
                    { "c35b151f-e2a9-483f-a367-bafdfddee1d1", null, "Admin", "ADMIN" }
                });
        }
    }
}
