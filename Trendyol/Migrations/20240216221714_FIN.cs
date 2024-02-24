using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendyol.Migrations
{
    /// <inheritdoc />
    public partial class FIN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FIN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FIN",
                table: "Products");
        }
    }
}
