using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class addComment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_books_bookId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_clients_clientid",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_clientid",
                table: "comments",
                newName: "IX_comments_clientid");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_bookId",
                table: "comments",
                newName: "IX_comments_bookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_books_bookId",
                table: "comments",
                column: "bookId",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_clients_clientid",
                table: "comments",
                column: "clientid",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_books_bookId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_clients_clientid",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_comments_clientid",
                table: "Comment",
                newName: "IX_Comment_clientid");

            migrationBuilder.RenameIndex(
                name: "IX_comments_bookId",
                table: "Comment",
                newName: "IX_Comment_bookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_books_bookId",
                table: "Comment",
                column: "bookId",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_clients_clientid",
                table: "Comment",
                column: "clientid",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
