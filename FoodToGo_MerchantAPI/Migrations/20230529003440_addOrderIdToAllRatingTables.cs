using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class addOrderIdToAllRatingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "UserRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MerchantRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MenuItemRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_OrderId",
                table: "UserRatings",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantRatings_OrderId",
                table: "MerchantRatings",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRatings_OrderId",
                table: "MenuItemRatings",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRatings_Orders_OrderId",
                table: "MenuItemRatings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantRatings_Orders_OrderId",
                table: "MerchantRatings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Orders_OrderId",
                table: "UserRatings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRatings_Orders_OrderId",
                table: "MenuItemRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantRatings_Orders_OrderId",
                table: "MerchantRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Orders_OrderId",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserRatings_OrderId",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_MerchantRatings_OrderId",
                table: "MerchantRatings");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemRatings_OrderId",
                table: "MenuItemRatings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MerchantRatings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MenuItemRatings");
        }
    }
}
