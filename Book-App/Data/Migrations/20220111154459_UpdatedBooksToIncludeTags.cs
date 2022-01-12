using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_App.Data.Migrations
{
    public partial class UpdatedBooksToIncludeTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TagAllocations_BookId",
                table: "TagAllocations");

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagAllocations_BookId",
                table: "TagAllocations",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_TagsId",
                table: "Books",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Tags_TagsId",
                table: "Books",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Tags_TagsId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_TagAllocations_BookId",
                table: "TagAllocations");

            migrationBuilder.DropIndex(
                name: "IX_Books_TagsId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_TagAllocations_BookId",
                table: "TagAllocations",
                column: "BookId");
        }
    }
}
