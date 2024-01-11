using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galerie_Arta_Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeces = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nationalitate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nr_telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tablou",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_realizare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dimensiune = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablou", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tablou_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TablouID = table.Column<int>(type: "int", nullable: true),
                    UtilizatorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programare_Tablou_TablouID",
                        column: x => x.TablouID,
                        principalTable: "Tablou",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Utilizator_UtilizatorID",
                        column: x => x.UtilizatorID,
                        principalTable: "Utilizator",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_TablouID",
                table: "Programare",
                column: "TablouID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_UtilizatorID",
                table: "Programare",
                column: "UtilizatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tablou_ArtistID",
                table: "Tablou",
                column: "ArtistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "Tablou");

            migrationBuilder.DropTable(
                name: "Utilizator");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
