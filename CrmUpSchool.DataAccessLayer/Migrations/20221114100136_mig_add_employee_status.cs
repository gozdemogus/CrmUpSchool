using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmUpSchool.DataAccessLayer.Migrations
{
    public partial class mig_add_employee_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmployeeStatus",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeStatus",
                table: "Employees");
        }
    }
}
