using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class addMerchantProfileImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemImages_MenuItems_MenuItemId",
                table: "MenuItemImages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MenuItemImages",
                newName: "FileName");

            migrationBuilder.CreateTable(
                name: "MerchantProfileImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantProfileImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantProfileImages_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantProfileImages_MerchantId",
                table: "MerchantProfileImages",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemImages_MenuItems_MenuItemId",
                table: "MenuItemImages",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemImages_MenuItems_MenuItemId",
                table: "MenuItemImages");

            migrationBuilder.DropTable(
                name: "MerchantProfileImages");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "MenuItemImages",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemImages_MenuItems_MenuItemId",
                table: "MenuItemImages",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
