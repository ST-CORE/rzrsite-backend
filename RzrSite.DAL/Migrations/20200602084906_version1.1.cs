using Microsoft.EntityFrameworkCore.Migrations;

namespace RzrSite.DAL.Migrations
{
  public partial class version11 : Migration
  {
    //Adds nullable tables (in order to create initial image)
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable("Documents");
      migrationBuilder.DropTable("Image");
      migrationBuilder.DropTable("Products");

      migrationBuilder.CreateTable(
          name: "Documents",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Description = table.Column<string>(nullable: true),
            Weight = table.Column<int>(nullable: false),
            FileId = table.Column<int>(nullable: true),
            ProductLineId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Documents", x => x.Id);
            table.ForeignKey(
                      name: "FK_Documents_ProductLines_ProductLineId",
                      column: x => x.ProductLineId,
                      principalTable: "ProductLines",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Image",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Description = table.Column<string>(nullable: true),
            Weight = table.Column<int>(nullable: false),
            FullId = table.Column<int>(nullable: true),
            ThumbId = table.Column<int>(nullable: true),
            ProductId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Image", x => x.Id);
            table.ForeignKey(
                      name: "FK_Image_DbFile_FullId",
                      column: x => x.FullId,
                      principalTable: "DbFile",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Image_DbFile_ThumbId",
                      column: x => x.ThumbId,
                      principalTable: "DbFile",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Products",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(nullable: true),
            Title = table.Column<string>(nullable: true),
            Price = table.Column<decimal>(nullable: false),
            InStock = table.Column<bool>(nullable: false),
            Path = table.Column<string>(nullable: true),
            Weight = table.Column<int>(nullable: false),
            ProductLineId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Products", x => x.Id);
            table.ForeignKey(
                      name: "FK_Products_ProductLines_ProductLineId",
                      column: x => x.ProductLineId,
                      principalTable: "ProductLines",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable("Documents");
      migrationBuilder.DropTable("Image");
      migrationBuilder.DropTable("Products");


      migrationBuilder.CreateTable(
          name: "Documents",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Description = table.Column<string>(nullable: true),
            Weight = table.Column<int>(nullable: false),
            FileId = table.Column<int>(nullable: false),
            ProductLineId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Documents", x => x.Id);
            table.ForeignKey(
                      name: "FK_Documents_ProductLines_ProductLineId",
                      column: x => x.ProductLineId,
                      principalTable: "ProductLines",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Image",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Description = table.Column<string>(nullable: true),
            Weight = table.Column<int>(nullable: false),
            FullId = table.Column<int>(nullable: false),
            ThumbId = table.Column<int>(nullable: false),
            ProductId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Image", x => x.Id);
            table.ForeignKey(
                      name: "FK_Image_DbFile_FullId",
                      column: x => x.FullId,
                      principalTable: "DbFile",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Image_DbFile_ThumbId",
                      column: x => x.ThumbId,
                      principalTable: "DbFile",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Products",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(nullable: true),
            Title = table.Column<string>(nullable: true),
            Price = table.Column<decimal>(nullable: false),
            InStock = table.Column<bool>(nullable: false),
            Path = table.Column<string>(nullable: true),
            Weight = table.Column<int>(nullable: false),
            ProductLineId = table.Column<int>(nullable: false),
            PrimaryImageId = table.Column<int?>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Products", x => x.Id);
            table.ForeignKey(
                      name: "FK_Products_Image_PrimaryImageId",
                      column: x => x.PrimaryImageId,
                      principalTable: "Image",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Products_ProductLines_ProductLineId",
                      column: x => x.ProductLineId,
                      principalTable: "ProductLines",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });
    }
  }
}