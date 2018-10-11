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
                    ManagerName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
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
                    BandName = table.Column<string>(nullable: false),
                    Members = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    Origin = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    DateFounded = table.Column<int>(nullable: false),
                    ManagerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Band", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Band_Manager_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConcertName = table.Column<string>(nullable: false),
                    Venue = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TicketPrice = table.Column<decimal>(nullable: false),
                    BandID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concert_Band_BandID",
                        column: x => x.BandID,
                        principalTable: "Band",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Duration = table.Column<string>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    BandID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Band_BandID",
                        column: x => x.BandID,
                        principalTable: "Band",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Band_ManagerID",
                table: "Band",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Concert_BandID",
                table: "Concert",
                column: "BandID");

            migrationBuilder.CreateIndex(
                name: "IX_Song_BandID",
                table: "Song",
                column: "BandID");
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
