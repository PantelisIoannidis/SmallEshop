using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallEshop.Infrastructure.Migrations
{
    public partial class BasketItemFixes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Items_ItemId",
                table: "BasketItems");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "BasketItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Items_ItemId",
                table: "BasketItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Items_ItemId",
                table: "BasketItems");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "BasketItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Items_ItemId",
                table: "BasketItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
