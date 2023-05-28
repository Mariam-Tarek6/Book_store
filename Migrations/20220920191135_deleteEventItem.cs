using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class deleteEventItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "shoppingBaskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Iqty",
                table: "shoppingBasket_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "eventId",
                table: "shoppingBasket_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBasket_Books_eventId",
                table: "shoppingBasket_Books",
                column: "eventId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBasket_Books_events_eventId",
                table: "shoppingBasket_Books",
                column: "eventId",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingBasket_Books_events_eventId",
                table: "shoppingBasket_Books");

            migrationBuilder.DropIndex(
                name: "IX_shoppingBasket_Books_eventId",
                table: "shoppingBasket_Books");

            migrationBuilder.DropColumn(
                name: "date",
                table: "shoppingBaskets");

            migrationBuilder.DropColumn(
                name: "Iqty",
                table: "shoppingBasket_Books");

            migrationBuilder.DropColumn(
                name: "eventId",
                table: "shoppingBasket_Books");

            migrationBuilder.CreateTable(
                name: "eventItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shopping_BasketId = table.Column<int>(type: "int", nullable: false),
                    basketid = table.Column<int>(type: "int", nullable: true),
                    eventId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_eventItems_basketid",
                table: "eventItems",
                column: "basketid");

            migrationBuilder.CreateIndex(
                name: "IX_eventItems_eventId",
                table: "eventItems",
                column: "eventId");
        }
    }
}
