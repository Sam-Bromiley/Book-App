using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_App.Data.Migrations
{
    public partial class UpdatedTagAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagAllocations_AspNetUsers_UserId",
                table: "TagAllocations");

            migrationBuilder.DropIndex(
                name: "IX_TagAllocations_UserId",
                table: "TagAllocations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TagAllocations");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "TagAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TagAllocations_BookId",
                table: "TagAllocations",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagAllocations_Books_BookId",
                table: "TagAllocations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagAllocations_Books_BookId",
                table: "TagAllocations");

            migrationBuilder.DropIndex(
                name: "IX_TagAllocations_BookId",
                table: "TagAllocations");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "TagAllocations");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TagAllocations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagAllocations_UserId",
                table: "TagAllocations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagAllocations_AspNetUsers_UserId",
                table: "TagAllocations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
