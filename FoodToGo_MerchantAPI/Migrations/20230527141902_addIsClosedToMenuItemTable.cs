using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class addIsClosedToMenuItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "MenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "MenuItems");
        }
    }
}
