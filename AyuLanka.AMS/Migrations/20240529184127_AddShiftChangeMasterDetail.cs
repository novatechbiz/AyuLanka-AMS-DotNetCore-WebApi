using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftChangeMasterDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftChangeMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffRosterMasterId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ShiftChangeReasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftChangeMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftChangeMasters_DayOffChangeReasons_ShiftChangeReasonId",
                        column: x => x.ShiftChangeReasonId,
                        principalTable: "DayOffChangeReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftChangeMasters_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftChangeMasters_StaffRosterMasters_StaffRosterMasterId",
                        column: x => x.StaffRosterMasterId,
                        principalTable: "StaffRosterMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftChangeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftChangeMasterId = table.Column<int>(type: "int", nullable: false),
                    StaffRosterId = table.Column<int>(type: "int", nullable: false),
                    ShiftPre = table.Column<int>(type: "int", nullable: false),
                    ShiftPost = table.Column<int>(type: "int", nullable: false),
                    ExchangeWithPre = table.Column<int>(type: "int", nullable: true),
                    ExchangeWithPost = table.Column<int>(type: "int", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftChangeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftChangeDetails_ShiftChangeMasters_ShiftChangeMasterId",
                        column: x => x.ShiftChangeMasterId,
                        principalTable: "ShiftChangeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftChangeDetails_ShiftChangeMasterId",
                table: "ShiftChangeDetails",
                column: "ShiftChangeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftChangeMasters_EmployeeId",
                table: "ShiftChangeMasters",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftChangeMasters_ShiftChangeReasonId",
                table: "ShiftChangeMasters",
                column: "ShiftChangeReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftChangeMasters_StaffRosterMasterId",
                table: "ShiftChangeMasters",
                column: "StaffRosterMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftChangeDetails");

            migrationBuilder.DropTable(
                name: "ShiftChangeMasters");
        }
    }
}
