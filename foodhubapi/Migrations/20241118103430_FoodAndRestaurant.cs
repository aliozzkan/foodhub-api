using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace foodhubapi.Migrations
{
    /// <inheritdoc />
    public partial class FoodAndRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b8418d-775b-4148-8be9-163156974595");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5840bf0-0924-452f-a31c-1a0f002c26ff");

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Restaurants_RestaurantId",
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
                    { "84b8887e-fee2-4b70-95ce-09ff7433855e", null, "Admin", "ADMIN" },
                    { "bb7c9062-0db9-4874-b269-7aab8165f3de", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RestaurantId",
                table: "Foods",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b8887e-fee2-4b70-95ce-09ff7433855e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb7c9062-0db9-4874-b269-7aab8165f3de");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b7b8418d-775b-4148-8be9-163156974595", null, "Admin", "ADMIN" },
                    { "d5840bf0-0924-452f-a31c-1a0f002c26ff", null, "User", "USER" }
                });
        }
    }
}
