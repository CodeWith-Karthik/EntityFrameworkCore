using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodStop.Migrations
{
    /// <inheritdoc />
    public partial class BranchDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Location", "Name", "Phone" },
                values: new object[,]
                {
                    { 4, "Covai", "SpiceFusion Kitchen", 123456789L },
                    { 5, "Dharmapuri", "SavoryBite Delights", 123456789L },
                    { 6, "Ambur", "CrispyCrust Cafe", 123456789L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
