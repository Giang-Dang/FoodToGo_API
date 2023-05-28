using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToGo_API.Migrations
{
    /// <inheritdoc />
    public partial class addMerchantRatingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MerchantRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<int>(type: "int", nullable: false),
                    FromUserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToMerchantId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantRatings_Merchants_ToMerchantId",
                        column: x => x.ToMerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId");
                    table.ForeignKey(
                        name: "FK_MerchantRatings_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantRatings_FromUserId",
                table: "MerchantRatings",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantRatings_ToMerchantId",
                table: "MerchantRatings",
                column: "ToMerchantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchantRatings");
        }
    }
}
