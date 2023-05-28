using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class DeleteEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_events_Event_id",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingBasket_Books_events_eventId",
                table: "shoppingBasket_Books");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropIndex(
                name: "IX_shoppingBasket_Books_eventId",
                table: "shoppingBasket_Books");

            migrationBuilder.DropIndex(
                name: "IX_books_Event_id",
                table: "books");

            migrationBuilder.DropColumn(
                name: "eventId",
                table: "shoppingBasket_Books");

            migrationBuilder.DropColumn(
                name: "Event_id",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "clients",
                newName: "email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "clients",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "eventId",
                table: "shoppingBasket_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Event_id",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Authorid = table.Column<int>(type: "int", nullable: true),
                    BOOKID = table.Column<int>(type: "int", nullable: true),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    author_Id = table.Column<int>(type: "int", nullable: false),
                    client_qty = table.Column<int>(type: "int", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: false),
                    ticketPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                    table.ForeignKey(
                        name: "FK_events_authors_Authorid",
                        column: x => x.Authorid,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_events_books_BOOKID",
                        column: x => x.BOOKID,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBasket_Books_eventId",
                table: "shoppingBasket_Books",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_books_Event_id",
                table: "books",
                column: "Event_id",
                unique: true,
                filter: "[Event_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_events_Authorid",
                table: "events",
                column: "Authorid");

            migrationBuilder.CreateIndex(
                name: "IX_events_BOOKID",
                table: "events",
                column: "BOOKID");

            migrationBuilder.AddForeignKey(
                name: "FK_books_events_Event_id",
                table: "books",
                column: "Event_id",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBasket_Books_events_eventId",
                table: "shoppingBasket_Books",
                column: "eventId",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
