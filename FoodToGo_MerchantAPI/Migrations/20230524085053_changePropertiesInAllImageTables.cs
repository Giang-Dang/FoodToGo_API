using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class changePropertiesInAllImageTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "MerchantProfileImages");

            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "MenuItemImages");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "MerchantProfileImages",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "MenuItemImages",
                newName: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "MerchantProfileImages",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "MenuItemImages",
                newName: "FileName");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFile",
                table: "MerchantProfileImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFile",
                table: "MenuItemImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
