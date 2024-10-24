using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class calling_name_and_employee_number_to_employee_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallingName",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNumber",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallingName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "Employees");
        }
    }
}
