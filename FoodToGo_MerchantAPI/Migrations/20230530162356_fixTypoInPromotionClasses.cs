using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class fixTypoInPromotionClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Merchants_DiscountCreatorMerchanId",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "DiscountCreatorMerchanId",
                table: "Promotions",
                newName: "DiscountCreatorMerchantId");

            migrationBuilder.RenameIndex(
                name: "IX_Promotions_DiscountCreatorMerchanId",
                table: "Promotions",
                newName: "IX_Promotions_DiscountCreatorMerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Merchants_DiscountCreatorMerchantId",
                table: "Promotions",
                column: "DiscountCreatorMerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Merchants_DiscountCreatorMerchantId",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "DiscountCreatorMerchantId",
                table: "Promotions",
                newName: "DiscountCreatorMerchanId");

            migrationBuilder.RenameIndex(
                name: "IX_Promotions_DiscountCreatorMerchantId",
                table: "Promotions",
                newName: "IX_Promotions_DiscountCreatorMerchanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Merchants_DiscountCreatorMerchanId",
                table: "Promotions",
                column: "DiscountCreatorMerchanId",
                principalTable: "Merchants",
                principalColumn: "MerchantId");
        }
    }
}
