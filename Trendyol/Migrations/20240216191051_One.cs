using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendyol.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductsForOrders_ProductsForOrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsForOrders_Users_UserId",
                table: "ProductsForOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductsForOrders_UserId",
                table: "ProductsForOrders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductsForOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductsForOrders");

            migrationBuilder.DropColumn(
                name: "ProductsForOrderId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductsForOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsForOrderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsForOrders_UserId",
                table: "ProductsForOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsForOrderId",
                table: "Orders",
                column: "ProductsForOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductsForOrders_ProductsForOrderId",
                table: "Orders",
                column: "ProductsForOrderId",
                principalTable: "ProductsForOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsForOrders_Users_UserId",
                table: "ProductsForOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
