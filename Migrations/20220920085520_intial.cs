using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher_Package",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher_Package", x => x.id);
                    table.ForeignKey(
                        name: "FK_Publisher_Package_publishers_publisherId",
                        column: x => x.publisherId,
                        principalTable: "publishers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorId = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    publisher_packageId = table.Column<int>(type: "int", nullable: false),
                    Event_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_books_authors_authorId",
                        column: x => x.authorId,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_Publisher_Package_publisher_packageId",
                        column: x => x.publisher_packageId,
                        principalTable: "Publisher_Package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    ticketPrice = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    client_qty = table.Column<int>(type: "int", nullable: false),
                    author_Id = table.Column<int>(type: "int", nullable: false),
                    Authorid = table.Column<int>(type: "int", nullable: true),
                    BOOKID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "shoppingBasket_Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    ShoppingBasketID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingBasket_Books", x => x.id);
                    table.ForeignKey(
                        name: "FK_shoppingBasket_Books_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppingBaskets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalPrice = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingBaskets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoppingBasketid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                    table.ForeignKey(
                        name: "FK_clients_shoppingBaskets_ShoppingBasketid",
                        column: x => x.ShoppingBasketid,
                        principalTable: "shoppingBaskets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "eventItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventId = table.Column<int>(type: "int", nullable: false),
                    Shopping_BasketId = table.Column<int>(type: "int", nullable: false),
                    basketid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_eventItems_events_eventId",
                        column: x => x.eventId,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventItems_shoppingBaskets_basketid",
                        column: x => x.basketid,
                        principalTable: "shoppingBaskets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _ShoppingBasketId = table.Column<int>(type: "int", nullable: false),
                    Basketid = table.Column<int>(type: "int", nullable: true),
                    totalPrice = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_shoppingBaskets_Basketid",
                        column: x => x.Basketid,
                        principalTable: "shoppingBaskets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_authorId",
                table: "books",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_categoryId",
                table: "books",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_books_Event_id",
                table: "books",
                column: "Event_id",
                unique: true,
                filter: "[Event_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_books_publisher_packageId",
                table: "books",
                column: "publisher_packageId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_ShoppingBasketid",
                table: "clients",
                column: "ShoppingBasketid");

            migrationBuilder.CreateIndex(
                name: "IX_eventItems_basketid",
                table: "eventItems",
                column: "basketid");

            migrationBuilder.CreateIndex(
                name: "IX_eventItems_eventId",
                table: "eventItems",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_events_Authorid",
                table: "events",
                column: "Authorid");

            migrationBuilder.CreateIndex(
                name: "IX_events_BOOKID",
                table: "events",
                column: "BOOKID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Basketid",
                table: "orders",
                column: "Basketid");

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_Package_publisherId",
                table: "Publisher_Package",
                column: "publisherId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBasket_Books_bookId",
                table: "shoppingBasket_Books",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBasket_Books_ShoppingBasketID",
                table: "shoppingBasket_Books",
                column: "ShoppingBasketID");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBaskets_clientId",
                table: "shoppingBaskets",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_events_Event_id",
                table: "books",
                column: "Event_id",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBasket_Books_shoppingBaskets_ShoppingBasketID",
                table: "shoppingBasket_Books",
                column: "ShoppingBasketID",
                principalTable: "shoppingBaskets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBaskets_clients_clientId",
                table: "shoppingBaskets",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_authors_authorId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_events_authors_Authorid",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_categoryId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_events_Event_id",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_clients_shoppingBaskets_ShoppingBasketid",
                table: "clients");

            migrationBuilder.DropTable(
                name: "eventItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "shoppingBasket_Books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "Publisher_Package");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "shoppingBaskets");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
