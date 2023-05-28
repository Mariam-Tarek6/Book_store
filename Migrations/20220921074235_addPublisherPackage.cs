using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class addPublisherPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Publisher_Package_publisher_packageId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_Publisher_Package_publishers_publisherId",
                table: "Publisher_Package");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher_Package",
                table: "Publisher_Package");

            migrationBuilder.RenameTable(
                name: "Publisher_Package",
                newName: "publisher_Packages");

            migrationBuilder.RenameIndex(
                name: "IX_Publisher_Package_publisherId",
                table: "publisher_Packages",
                newName: "IX_publisher_Packages_publisherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_publisher_Packages",
                table: "publisher_Packages",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_publisher_Packages_publisher_packageId",
                table: "books",
                column: "publisher_packageId",
                principalTable: "publisher_Packages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publisher_Packages_publishers_publisherId",
                table: "publisher_Packages",
                column: "publisherId",
                principalTable: "publishers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_publisher_Packages_publisher_packageId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_publisher_Packages_publishers_publisherId",
                table: "publisher_Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_publisher_Packages",
                table: "publisher_Packages");

            migrationBuilder.RenameTable(
                name: "publisher_Packages",
                newName: "Publisher_Package");

            migrationBuilder.RenameIndex(
                name: "IX_publisher_Packages_publisherId",
                table: "Publisher_Package",
                newName: "IX_Publisher_Package_publisherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher_Package",
                table: "Publisher_Package",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_Publisher_Package_publisher_packageId",
                table: "books",
                column: "publisher_packageId",
                principalTable: "Publisher_Package",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publisher_Package_publishers_publisherId",
                table: "Publisher_Package",
                column: "publisherId",
                principalTable: "publishers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
