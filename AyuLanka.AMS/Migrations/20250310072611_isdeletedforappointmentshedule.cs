using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class isdeletedforappointmentshedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "AppointmentSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "AppointmentSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppointmentSchedules",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_DeletedBy",
                table: "AppointmentSchedules",
                column: "DeletedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Employees_DeletedBy",
                table: "AppointmentSchedules",
                column: "DeletedBy",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Employees_DeletedBy",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_DeletedBy",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppointmentSchedules");
        }
    }
}
