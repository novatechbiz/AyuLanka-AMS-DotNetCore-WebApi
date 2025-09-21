using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmentScheduleChitNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChitNo",
                table: "AppointmentSchedules",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChitNo",
                table: "AppointmentSchedules");
        }
    }
}
