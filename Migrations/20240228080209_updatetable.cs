using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Management1.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeSalary_SalaryId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SalaryId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeSalarySalaryId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeSalarySalaryId",
                table: "Employee",
                column: "EmployeeSalarySalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeSalary_EmployeeSalarySalaryId",
                table: "Employee",
                column: "EmployeeSalarySalaryId",
                principalTable: "EmployeeSalary",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeSalary_EmployeeSalarySalaryId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeSalarySalaryId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeSalarySalaryId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SalaryId",
                table: "Employee",
                column: "SalaryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeSalary_SalaryId",
                table: "Employee",
                column: "SalaryId",
                principalTable: "EmployeeSalary",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
