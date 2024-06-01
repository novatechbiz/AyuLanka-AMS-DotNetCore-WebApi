using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDayOffChangeDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayOffChangeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOffChangeMasterId = table.Column<int>(type: "int", nullable: false),
                    StaffRosterId = table.Column<int>(type: "int", nullable: false),
                    DayOffPre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOffPost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExchangeWithPre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExchangeWithPost = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOffChangeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOffChangeDetails_DayOffChangeMasters_DayOffChangeMasterId",
                        column: x => x.DayOffChangeMasterId,
                        principalTable: "DayOffChangeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayOffChangeDetails_DayOffChangeMasterId",
                table: "DayOffChangeDetails",
                column: "DayOffChangeMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOffChangeDetails");
        }
    }
}
