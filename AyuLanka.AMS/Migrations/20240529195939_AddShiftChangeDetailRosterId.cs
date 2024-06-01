using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftChangeDetailRosterId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShiftChangeDetails_StaffRosterId",
                table: "ShiftChangeDetails",
                column: "StaffRosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftChangeDetails_StaffRosters_StaffRosterId",
                table: "ShiftChangeDetails",
                column: "StaffRosterId",
                principalTable: "StaffRosters",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShiftChangeDetails_StaffRosters_StaffRosterId",
                table: "ShiftChangeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShiftChangeDetails_StaffRosterId",
                table: "ShiftChangeDetails");
        }
    }
}
