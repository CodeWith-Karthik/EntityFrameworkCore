using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandTex.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetEmployees
             AS
             SELECT e.Id AS EmployeeId,
             e.FirstName AS Name,
             d.Name AS Department,
             e.EmployedFrom AS EmployedYear
             FROM Employee e
             JOIN Department d ON e.DepartmentId = d.Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.GetEmployees");
        }
    }
}
