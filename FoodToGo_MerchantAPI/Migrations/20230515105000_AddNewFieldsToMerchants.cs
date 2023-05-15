using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToMerchants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "BanLength",
                table: "Merchants",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "BanReason",
                table: "Merchants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BanStartTime",
                table: "Merchants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseHour_1",
                table: "Merchants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseHour_2",
                table: "Merchants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Merchants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHour_1",
                table: "Merchants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHour_2",
                table: "Merchants",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanLength",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "BanReason",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "BanStartTime",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "CloseHour_1",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "CloseHour_2",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "OpenHour_1",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "OpenHour_2",
                table: "Merchants");
        }
    }
}
