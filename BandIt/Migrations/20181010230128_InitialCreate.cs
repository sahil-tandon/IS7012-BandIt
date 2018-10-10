using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandIt.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManagerName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Band",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BandName = table.Column<string>(nullable: true),
                    Members = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    DateFounded = table.Column<DateTime>(nullable: true),
                    BandManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Band", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Band_Manager_BandManagerId",
                        column: x => x.BandManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConcertName = table.Column<string>(nullable: true),
                    Venue = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    TicketPrice = table.Column<decimal>(nullable: false),
                    PerformingBandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concert_Band_PerformingBandId",
                        column: x => x.PerformingBandId,
                        principalTable: "Band",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    ArtistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Band_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Band",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Band_BandManagerId",
                table: "Band",
                column: "BandManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Concert_PerformingBandId",
                table: "Concert",
                column: "PerformingBandId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_ArtistId",
                table: "Song",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Band");

            migrationBuilder.DropTable(
                name: "Manager");
        }
    }
}
