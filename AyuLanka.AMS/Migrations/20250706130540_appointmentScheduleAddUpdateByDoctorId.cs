using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class appointmentScheduleAddUpdateByDoctorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorEmployeeId",
                table: "AppointmentSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "AppointmentSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AppointmentSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_DoctorEmployeeId",
                table: "AppointmentSchedules",
                column: "DoctorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_UpdatedBy",
                table: "AppointmentSchedules",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Employees_DoctorEmployeeId",
                table: "AppointmentSchedules",
                column: "DoctorEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Employees_UpdatedBy",
                table: "AppointmentSchedules",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Employees_DoctorEmployeeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Employees_UpdatedBy",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_DoctorEmployeeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_UpdatedBy",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "DoctorEmployeeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AppointmentSchedules");
        }
    }
}
