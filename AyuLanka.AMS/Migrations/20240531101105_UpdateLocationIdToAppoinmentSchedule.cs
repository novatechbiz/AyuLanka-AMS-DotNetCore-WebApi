using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocationIdToAppoinmentSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_TreatmentTypes_TreatmentTypeId",
                table: "AppointmentSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_TreatmentLocations_TreatmentTypeId",
                table: "AppointmentSchedules",
                column: "TreatmentTypeId",
                principalTable: "TreatmentLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_TreatmentLocations_TreatmentTypeId",
                table: "AppointmentSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_TreatmentTypes_TreatmentTypeId",
                table: "AppointmentSchedules",
                column: "TreatmentTypeId",
                principalTable: "TreatmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
