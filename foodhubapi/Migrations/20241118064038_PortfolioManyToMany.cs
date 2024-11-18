using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace foodhubapi.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c7ed2fd-ce9f-42af-a6ad-578ce843c107");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c2eef6-31a7-4b0e-b8e5-8c4de81f67bc");

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    StockId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => new { x.AppUserId, x.StockId });
                    table.ForeignKey(
                        name: "FK_Portfolios_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d49799ec-d42a-4776-80d7-7024a63ac87d", null, "User", "USER" },
                    { "d735d90f-0421-4757-a1fe-483ff2a1ece3", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_StockId",
                table: "Portfolios",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d49799ec-d42a-4776-80d7-7024a63ac87d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d735d90f-0421-4757-a1fe-483ff2a1ece3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c7ed2fd-ce9f-42af-a6ad-578ce843c107", null, "User", "USER" },
                    { "e3c2eef6-31a7-4b0e-b8e5-8c4de81f67bc", null, "Admin", "ADMIN" }
                });
        }
    }
}
