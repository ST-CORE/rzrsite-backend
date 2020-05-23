using Microsoft.EntityFrameworkCore.Migrations;

namespace RzrSite.DAL.Migrations
{
  public partial class Products : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Products",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(nullable: true),
            Path = table.Column<string>(nullable: true),
            Title = table.Column<string>(nullable: true),
            Price = table.Column<decimal>(nullable: false),
            InStock = table.Column<bool>(nullable: false),
            Weight = table.Column<int>(nullable: false),
            ProductLineId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Products", x => x.Id);
            table.ForeignKey(
                      name: "FK_Products_ProductLines_ProductLineId",
                      column: x => x.ProductLineId,
                      principalTable: "ProductLines",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });


      migrationBuilder.CreateIndex(
          name: "IX_Products_ProductLineId",
          table: "Products",
          column: "ProductLineId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable("Products");
    }
  }
}
