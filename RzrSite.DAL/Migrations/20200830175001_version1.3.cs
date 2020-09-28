using Microsoft.EntityFrameworkCore.Migrations;

namespace RzrSite.DAL.Migrations
{
  public partial class version13 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<int>(
          name: "CategoryId",
          table: "FeatureType",
          nullable: false,
          defaultValue: 0);
      
      migrationBuilder.AddColumn<string>(
          name: "Units",
          table: "FeatureType",
          nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "CategoryId",
          table: "FeatureType");

      migrationBuilder.DropColumn(
          name: "Units",
          table: "FeatureType");
    }
  }
}
