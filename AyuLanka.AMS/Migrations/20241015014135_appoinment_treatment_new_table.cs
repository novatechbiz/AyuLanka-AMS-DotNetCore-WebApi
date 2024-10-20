using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class appoinment_treatment_new_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Employees_EmployeeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_TreatmentLocations_TreatmentTypeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_TreatmentTypeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "TreatmentTypeId",
                table: "AppointmentSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TreatmentTypes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DurationMinutes",
                table: "TreatmentTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "AppointmentSchedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "AppointmentSchedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppoinmentTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppoinmentId = table.Column<int>(type: "int", nullable: false),
                    TreatmentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppoinmentTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppoinmentTreatments_AppointmentSchedules_AppoinmentId",
                        column: x => x.AppoinmentId,
                        principalTable: "AppointmentSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppoinmentTreatments_TreatmentLocations_TreatmentTypeId",
                        column: x => x.TreatmentTypeId,
                        principalTable: "TreatmentLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppoinmentTreatments_AppoinmentId",
                table: "AppoinmentTreatments",
                column: "AppoinmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppoinmentTreatments_TreatmentTypeId",
                table: "AppoinmentTreatments",
                column: "TreatmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Employees_EmployeeId",
                table: "AppointmentSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Employees_EmployeeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropTable(
                name: "AppoinmentTreatments");

            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "TreatmentTypes");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "AppointmentSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TreatmentTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "AppointmentSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentTypeId",
                table: "AppointmentSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_TreatmentTypeId",
                table: "AppointmentSchedules",
                column: "TreatmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Employees_EmployeeId",
                table: "AppointmentSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_TreatmentLocations_TreatmentTypeId",
                table: "AppointmentSchedules",
                column: "TreatmentTypeId",
                principalTable: "TreatmentLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
