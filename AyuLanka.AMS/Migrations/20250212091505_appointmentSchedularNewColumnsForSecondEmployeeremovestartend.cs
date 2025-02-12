using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class appointmentSchedularNewColumnsForSecondEmployeeremovestartend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromTimeSecond",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "ToTimeSecond",
                table: "AppointmentSchedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "FromTimeSecond",
                table: "AppointmentSchedules",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ToTimeSecond",
                table: "AppointmentSchedules",
                type: "time",
                nullable: true);
        }
    }
}
