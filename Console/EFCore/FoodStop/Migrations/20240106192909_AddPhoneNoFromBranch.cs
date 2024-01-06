using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodStop.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNoFromBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Phone",
                table: "Branch",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Branch");
        }
    }
}
