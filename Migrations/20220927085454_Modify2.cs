using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class Modify2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_shoppingBaskets_ShoppingBasketid",
                table: "clients");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingBasketid",
                table: "clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_shoppingBaskets_ShoppingBasketid",
                table: "clients",
                column: "ShoppingBasketid",
                principalTable: "shoppingBaskets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_shoppingBaskets_ShoppingBasketid",
                table: "clients");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingBasketid",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_clients_shoppingBaskets_ShoppingBasketid",
                table: "clients",
                column: "ShoppingBasketid",
                principalTable: "shoppingBaskets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
