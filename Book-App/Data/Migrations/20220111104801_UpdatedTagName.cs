using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_App.Data.Migrations
{
    public partial class UpdatedTagName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tags",
                newName: "TagName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "Tags",
                newName: "Name");
        }
    }
}
