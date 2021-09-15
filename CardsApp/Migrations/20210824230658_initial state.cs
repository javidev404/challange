using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardsApp.Migrations
{
    public partial class initialstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    IdCard = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cardHolder = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdPerson = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Limit = table.Column<long>(type: "bigint", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Brand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK_Card_Person_IdCard",
                        column: x => x.IdCard,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "IdPerson", "Lastname", "DNI", "Adress", "Name" },
                values: new object[] { 1, "Cabrera", "30303030", "Calle 123", "Javier" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Name", "NameUser", "Password" },
                values: new object[] { 1, "Javier", "Javier", "Cabrera" });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "IdCard", "IdPerson", "Limit", "Brand", "Name", "Number", "Rate", "cardHolder", "Expiration" },
                values: new object[] { 1, 1, 100000L, 2, "Javier", "00000000", 0.80000000000000004, "Javier", new DateTime(2021, 8, 24, 20, 6, 57, 721, DateTimeKind.Local).AddTicks(3744) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
