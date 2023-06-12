using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class addRatingToAllPossibleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Shippers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Merchants",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "MenuItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Customers");
        }
    }
}
