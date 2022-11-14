using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmUpSchool.DataAccessLayer.Migrations
{
    public partial class mig_add_employeetask_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeTasks_Employees_EmployeeID",
                table: "employeeTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeTasks",
                table: "employeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_employeeTasks_EmployeeID",
                table: "employeeTasks");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "employeeTasks");

            migrationBuilder.RenameTable(
                name: "employeeTasks",
                newName: "EmployeeTasks");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "EmployeeTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks",
                column: "EmployeeTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_AppUserId",
                table: "EmployeeTasks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_AspNetUsers_AppUserId",
                table: "EmployeeTasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_AspNetUsers_AppUserId",
                table: "EmployeeTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_AppUserId",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "EmployeeTasks");

            migrationBuilder.RenameTable(
                name: "EmployeeTasks",
                newName: "employeeTasks");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "employeeTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeTasks",
                table: "employeeTasks",
                column: "EmployeeTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_employeeTasks_EmployeeID",
                table: "employeeTasks",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_employeeTasks_Employees_EmployeeID",
                table: "employeeTasks",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
