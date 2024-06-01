using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffRosterMasterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RosterDate",
                table: "StaffRosters");

            migrationBuilder.AddColumn<int>(
                name: "RosterMasterId",
                table: "StaffRosters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StaffRosterMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Todate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRosterMasters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffRosters_RosterMasterId",
                table: "StaffRosters",
                column: "RosterMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRosters_StaffRosterMasters_RosterMasterId",
                table: "StaffRosters",
                column: "RosterMasterId",
                principalTable: "StaffRosterMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffRosters_StaffRosterMasters_RosterMasterId",
                table: "StaffRosters");

            migrationBuilder.DropTable(
                name: "StaffRosterMasters");

            migrationBuilder.DropIndex(
                name: "IX_StaffRosters_RosterMasterId",
                table: "StaffRosters");

            migrationBuilder.DropColumn(
                name: "RosterMasterId",
                table: "StaffRosters");

            migrationBuilder.AddColumn<DateTime>(
                name: "RosterDate",
                table: "StaffRosters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
