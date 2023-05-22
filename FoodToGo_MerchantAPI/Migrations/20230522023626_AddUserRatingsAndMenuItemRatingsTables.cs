using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRatingsAndMenuItemRatingsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerRating",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MerchantRating",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipperRating",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "GeoLongtitude",
                table: "OnlineCustomerLocations",
                newName: "GeoLongitude");

            migrationBuilder.RenameColumn(
                name: "GeoLongtitude",
                table: "Merchants",
                newName: "GeoLongitude");

            migrationBuilder.CreateTable(
                name: "MenuItemRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemRatings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_MenuItemRatings_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<int>(type: "int", nullable: false),
                    FromUserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToUserId = table.Column<int>(type: "int", nullable: false),
                    ToUserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRatings_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRatings_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRatings_CustomerId",
                table: "MenuItemRatings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRatings_MenuItemId",
                table: "MenuItemRatings",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_FromUserId",
                table: "UserRatings",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_ToUserId",
                table: "UserRatings",
                column: "ToUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemRatings");

            migrationBuilder.DropTable(
                name: "UserRatings");

            migrationBuilder.RenameColumn(
                name: "GeoLongitude",
                table: "OnlineCustomerLocations",
                newName: "GeoLongtitude");

            migrationBuilder.RenameColumn(
                name: "GeoLongitude",
                table: "Merchants",
                newName: "GeoLongtitude");

            migrationBuilder.AddColumn<float>(
                name: "CustomerRating",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MerchantRating",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ShipperRating",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
