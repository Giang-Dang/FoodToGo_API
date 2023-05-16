using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class AddNormalOpeHoursAndOverrideOpenHoursTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseHour_1",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "CloseHour_2",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "OpenHour_1",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "OpenHour_2",
                table: "Merchants");

            migrationBuilder.CreateTable(
                name: "NormalOpenHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    SessionNo = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalOpenHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormalOpenHours_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OverrideOpenHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    OverrideStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OverrideEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    SessionNo = table.Column<int>(type: "int", nullable: false),
                    AltOpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AltCloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverrideOpenHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverrideOpenHours_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NormalOpenHours_MerchantId",
                table: "NormalOpenHours",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_OverrideOpenHours_MerchantId",
                table: "OverrideOpenHours",
                column: "MerchantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormalOpenHours");

            migrationBuilder.DropTable(
                name: "OverrideOpenHours");

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
    }
}
