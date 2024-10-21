using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class appointment_treatment_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppoinmentTreatments_TreatmentLocations_TreatmentTypeId",
                table: "AppoinmentTreatments");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AppointmentSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_LocationId",
                table: "AppointmentSchedules",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppoinmentTreatments_TreatmentTypes_TreatmentTypeId",
                table: "AppoinmentTreatments",
                column: "TreatmentTypeId",
                principalTable: "TreatmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Locations_LocationId",
                table: "AppointmentSchedules",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppoinmentTreatments_TreatmentTypes_TreatmentTypeId",
                table: "AppoinmentTreatments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Locations_LocationId",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_LocationId",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AppointmentSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_AppoinmentTreatments_TreatmentLocations_TreatmentTypeId",
                table: "AppoinmentTreatments",
                column: "TreatmentTypeId",
                principalTable: "TreatmentLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
