using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace foodhubapi.Migrations
{
    /// <inheritdoc />
    public partial class FoodMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b8887e-fee2-4b70-95ce-09ff7433855e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb7c9062-0db9-4874-b269-7aab8165f3de");

            migrationBuilder.CreateTable(
                name: "FoodMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    Timing = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMenus_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodMenus_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "af1a8e3d-8aed-440e-8e4a-1323d4fb9d8c", null, "User", "USER" },
                    { "c35b151f-e2a9-483f-a367-bafdfddee1d1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenus_FoodId",
                table: "FoodMenus",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenus_RestaurantId",
                table: "FoodMenus",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMenus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af1a8e3d-8aed-440e-8e4a-1323d4fb9d8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c35b151f-e2a9-483f-a367-bafdfddee1d1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84b8887e-fee2-4b70-95ce-09ff7433855e", null, "Admin", "ADMIN" },
                    { "bb7c9062-0db9-4874-b269-7aab8165f3de", null, "User", "USER" }
                });
        }
    }
}
