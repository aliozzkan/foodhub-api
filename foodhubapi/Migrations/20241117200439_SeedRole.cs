using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace foodhubapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c7ed2fd-ce9f-42af-a6ad-578ce843c107", null, "User", "USER" },
                    { "e3c2eef6-31a7-4b0e-b8e5-8c4de81f67bc", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c7ed2fd-ce9f-42af-a6ad-578ce843c107");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c2eef6-31a7-4b0e-b8e5-8c4de81f67bc");
        }
    }
}
