using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodStop.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhoneNoFromBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Branch");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PhoneNo",
                table: "Branch",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
