using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumnstoappointmentschedular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "ActualFromTime",
                table: "AppointmentSchedules",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ActualToTime",
                table: "AppointmentSchedules",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryEmployeeId",
                table: "AppointmentSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_SecondaryEmployeeId",
                table: "AppointmentSchedules",
                column: "SecondaryEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Employees_SecondaryEmployeeId",
                table: "AppointmentSchedules",
                column: "SecondaryEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Employees_SecondaryEmployeeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_SecondaryEmployeeId",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "ActualFromTime",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "ActualToTime",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "SecondaryEmployeeId",
                table: "AppointmentSchedules");
        }
    }
}
