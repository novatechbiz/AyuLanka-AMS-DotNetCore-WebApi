using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftChangeDetailSHiftMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShiftChangeDetails_ShiftPost",
                table: "ShiftChangeDetails",
                column: "ShiftPost");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftChangeDetails_ShiftPre",
                table: "ShiftChangeDetails",
                column: "ShiftPre");

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftChangeDetails_ShiftMasters_ShiftPost",
                table: "ShiftChangeDetails",
                column: "ShiftPost",
                principalTable: "ShiftMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftChangeDetails_ShiftMasters_ShiftPre",
                table: "ShiftChangeDetails",
                column: "ShiftPre",
                principalTable: "ShiftMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShiftChangeDetails_ShiftMasters_ShiftPost",
                table: "ShiftChangeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftChangeDetails_ShiftMasters_ShiftPre",
                table: "ShiftChangeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShiftChangeDetails_ShiftPost",
                table: "ShiftChangeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShiftChangeDetails_ShiftPre",
                table: "ShiftChangeDetails");
        }
    }
}
