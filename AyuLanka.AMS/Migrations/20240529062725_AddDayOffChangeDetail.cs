using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class AddDayOffChangeDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOffChangeMasters_StaffRosters_StaffRosterId",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "DayOffPost",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "DayOffPre",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "ExchangeWithPost",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "ExchangeWithPre",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "DayOffChangeMasters");

            migrationBuilder.RenameColumn(
                name: "StaffRosterId",
                table: "DayOffChangeMasters",
                newName: "StaffRosterMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_DayOffChangeMasters_StaffRosterId",
                table: "DayOffChangeMasters",
                newName: "IX_DayOffChangeMasters_StaffRosterMasterId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "DayOffChangeMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DayOffChangeMasters_EmployeeId",
                table: "DayOffChangeMasters",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOffChangeMasters_Employees_EmployeeId",
                table: "DayOffChangeMasters",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOffChangeMasters_StaffRosterMasters_StaffRosterMasterId",
                table: "DayOffChangeMasters",
                column: "StaffRosterMasterId",
                principalTable: "StaffRosterMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOffChangeMasters_Employees_EmployeeId",
                table: "DayOffChangeMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOffChangeMasters_StaffRosterMasters_StaffRosterMasterId",
                table: "DayOffChangeMasters");

            migrationBuilder.DropIndex(
                name: "IX_DayOffChangeMasters_EmployeeId",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "DayOffChangeMasters");

            migrationBuilder.RenameColumn(
                name: "StaffRosterMasterId",
                table: "DayOffChangeMasters",
                newName: "StaffRosterId");

            migrationBuilder.RenameIndex(
                name: "IX_DayOffChangeMasters_StaffRosterMasterId",
                table: "DayOffChangeMasters",
                newName: "IX_DayOffChangeMasters_StaffRosterId");

            migrationBuilder.AddColumn<int>(
                name: "ApprovedBy",
                table: "DayOffChangeMasters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "DayOffChangeMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOffPost",
                table: "DayOffChangeMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOffPre",
                table: "DayOffChangeMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExchangeWithPost",
                table: "DayOffChangeMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExchangeWithPre",
                table: "DayOffChangeMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "DayOffChangeMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOffChangeMasters_StaffRosters_StaffRosterId",
                table: "DayOffChangeMasters",
                column: "StaffRosterId",
                principalTable: "StaffRosters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
