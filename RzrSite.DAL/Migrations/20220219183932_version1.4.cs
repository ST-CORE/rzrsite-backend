using Microsoft.EntityFrameworkCore.Migrations;

namespace RzrSite.DAL.Migrations
{
    public partial class version14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeaturesPDFId",
                table: "ProductLines",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLines_FeaturesPDFId",
                table: "ProductLines",
                column: "FeaturesPDFId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLines_DbFile_FeaturesPDFId",
                table: "ProductLines",
                column: "FeaturesPDFId",
                principalTable: "DbFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLines_DbFile_FeaturesPDFId",
                table: "ProductLines");

            migrationBuilder.DropIndex(
                name: "IX_ProductLines_FeaturesPDFId",
                table: "ProductLines");

            migrationBuilder.DropColumn(
                name: "FeaturesPDFId",
                table: "ProductLines");
        }
    }
}
