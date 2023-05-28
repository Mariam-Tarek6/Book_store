using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class addNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "orders",
                newName: "email");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "orders",
                newName: "Email");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
