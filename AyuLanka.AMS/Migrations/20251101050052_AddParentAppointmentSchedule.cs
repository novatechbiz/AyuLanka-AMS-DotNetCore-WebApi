using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class AddParentAppointmentSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentAppointmentScheduleId",
                table: "AppointmentSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_ParentAppointmentScheduleId",
                table: "AppointmentSchedules",
                column: "ParentAppointmentScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_AppointmentSchedules_ParentAppointmentScheduleId",
                table: "AppointmentSchedules",
                column: "ParentAppointmentScheduleId",
                principalTable: "AppointmentSchedules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_AppointmentSchedules_ParentAppointmentScheduleId",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_ParentAppointmentScheduleId",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "ParentAppointmentScheduleId",
                table: "AppointmentSchedules");
        }
    }
}
