using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallEshop.Infrastructure.Migrations
{
    public partial class BasketItemStoredAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StoredAt",
                table: "BasketItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoredAt",
                table: "BasketItems");
        }
    }
}
