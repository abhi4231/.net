using Microsoft.EntityFrameworkCore.Migrations;

namespace Webgentle.Bookstore.Migrations.Employee
{
    public partial class urladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeePdfUrl",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeePdfUrl",
                table: "Employee");
        }
    }
}
