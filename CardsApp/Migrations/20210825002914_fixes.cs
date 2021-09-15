using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardsApp.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Person_IdCard",
                table: "Card");

            migrationBuilder.AlterColumn<int>(
                name: "IdCard",
                table: "Card",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "IdCard",
                keyValue: 1,
                column: "Expiration",
                value: new DateTime(2021, 8, 24, 21, 29, 14, 115, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.CreateIndex(
                name: "IX_Card_IdPerson",
                table: "Card",
                column: "IdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Person_IdPerson",
                table: "Card",
                column: "IdPerson",
                principalTable: "Person",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Person_IdPerson",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_IdPerson",
                table: "Card");

            migrationBuilder.AlterColumn<int>(
                name: "IdCard",
                table: "Card",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "IdCard",
                keyValue: 1,
                column: "Expiration",
                value: new DateTime(2021, 8, 24, 20, 6, 57, 721, DateTimeKind.Local).AddTicks(3744));

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Person_IdCard",
                table: "Card",
                column: "IdCard",
                principalTable: "Person",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
