using Microsoft.EntityFrameworkCore.Migrations;

namespace RzrSite.DAL.Migrations
{
    public partial class version15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkToVideo",
                table: "ProductLines",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkToVideo",
                table: "ProductLines");
        }
    }
}
