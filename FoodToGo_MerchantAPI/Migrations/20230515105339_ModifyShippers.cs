using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyShippers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shippers_Users_ShipperId",
                table: "Shippers");

            migrationBuilder.RenameColumn(
                name: "ShipperId",
                table: "Shippers",
                newName: "UserId");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BanLength",
                table: "Shippers",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "BanReason",
                table: "Shippers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BanStartTime",
                table: "Shippers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Shippers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippers_Users_UserId",
                table: "Shippers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shippers_Users_UserId",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "BanLength",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "BanReason",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "BanStartTime",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Shippers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Shippers",
                newName: "ShipperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shippers_Users_ShipperId",
                table: "Shippers",
                column: "ShipperId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
