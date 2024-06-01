using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDayOffChangeMasterV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOffExchangeParentId",
                table: "DayOffChangeMasters");

            migrationBuilder.RenameColumn(
                name: "ChangeWith",
                table: "DayOffChangeMasters",
                newName: "ExchangeWithPre");

            migrationBuilder.RenameColumn(
                name: "ChangeTo",
                table: "DayOffChangeMasters",
                newName: "ExchangeWithPost");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOffPost",
                table: "DayOffChangeMasters");

            migrationBuilder.DropColumn(
                name: "DayOffPre",
                table: "DayOffChangeMasters");

            migrationBuilder.RenameColumn(
                name: "ExchangeWithPre",
                table: "DayOffChangeMasters",
                newName: "ChangeWith");

            migrationBuilder.RenameColumn(
                name: "ExchangeWithPost",
                table: "DayOffChangeMasters",
                newName: "ChangeTo");

            migrationBuilder.AddColumn<int>(
                name: "DayOffExchangeParentId",
                table: "DayOffChangeMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
