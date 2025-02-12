using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class appointmentSchedularNewColumnsForSecondEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "ActualFromTimeSecond",
                table: "AppointmentSchedules",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ActualToTimeSecond",
                table: "AppointmentSchedules",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FromTimeSecond",
                table: "AppointmentSchedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ToTimeSecond",
                table: "AppointmentSchedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_EnteredBy",
                table: "AppointmentSchedules",
                column: "EnteredBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Employees_EnteredBy",
                table: "AppointmentSchedules",
                column: "EnteredBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Employees_EnteredBy",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_EnteredBy",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "ActualFromTimeSecond",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "ActualToTimeSecond",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "FromTimeSecond",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "ToTimeSecond",
                table: "AppointmentSchedules");
        }
    }
}
