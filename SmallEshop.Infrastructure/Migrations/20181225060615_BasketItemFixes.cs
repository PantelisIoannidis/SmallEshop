using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallEshop.Infrastructure.Migrations
{
    public partial class BasketItemFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "BasketItems",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "BasketItems",
                newName: "Amount");
        }
    }
}
