using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGamesBackend.Migrations
{
    public partial class VideoGames011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videogames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreateDB = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDB = table.Column<bool>(type: "bit", nullable: false),
                    VideogameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Videogames_VideogameId",
                        column: x => x.VideogameId,
                        principalTable: "Videogames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_VideogameId",
                table: "Genres",
                column: "VideogameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Videogames");
        }
    }
}
