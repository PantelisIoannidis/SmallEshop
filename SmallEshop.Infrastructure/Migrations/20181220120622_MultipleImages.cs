using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallEshop.Infrastructure.Migrations
{
    public partial class MultipleImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailName",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemImagesId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "BrandName",
                table: "Brands",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ItemImages",
                columns: table => new
                {
                    ItemImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    DefaultImage = table.Column<bool>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: false),
                    PhotoThumbnailUrl = table.Column<string>(nullable: false),
                    PhotoDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImages", x => x.ItemImageId);
                    table.ForeignKey(
                        name: "FK_ItemImages_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_ItemId",
                table: "ItemImages",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemImages");

            migrationBuilder.DropColumn(
                name: "ItemImagesId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailName",
                table: "Items",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrandName",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
