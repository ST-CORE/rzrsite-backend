using Microsoft.EntityFrameworkCore.Migrations;

namespace RzrSite.DAL.Migrations
{
    public partial class AddShowOnMain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowOnMain",
                table: "ProductLines",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowOnMain",
                table: "ProductLines");
        }
    }
}
