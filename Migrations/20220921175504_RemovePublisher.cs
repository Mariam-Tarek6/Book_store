using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class RemovePublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_publisher_Packages_publisher_packageId",
                table: "books");

            migrationBuilder.DropTable(
                name: "publisher_Packages");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropIndex(
                name: "IX_books_publisher_packageId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "visa",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "publisher_packageId",
                table: "books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "visa",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "publisher_packageId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publisher_Packages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publisher_Packages", x => x.id);
                    table.ForeignKey(
                        name: "FK_publisher_Packages_publishers_publisherId",
                        column: x => x.publisherId,
                        principalTable: "publishers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_publisher_packageId",
                table: "books",
                column: "publisher_packageId");

            migrationBuilder.CreateIndex(
                name: "IX_publisher_Packages_publisherId",
                table: "publisher_Packages",
                column: "publisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_publisher_Packages_publisher_packageId",
                table: "books",
                column: "publisher_packageId",
                principalTable: "publisher_Packages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
