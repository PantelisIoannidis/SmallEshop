using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallEshop.Infrastructure.Migrations
{
    public partial class basketFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BasketItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BasketItems",
                nullable: true);
        }
    }
}
