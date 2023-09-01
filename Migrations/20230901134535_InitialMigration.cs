using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIALiens.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Populacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poderes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poderes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aliens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    DescAlien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetaId = table.Column<int>(type: "int", nullable: false),
                    IsOnEarth = table.Column<bool>(type: "bit", nullable: false),
                    DataEntradaTerra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataSaidaTerra = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aliens_Planetas_PlanetaId",
                        column: x => x.PlanetaId,
                        principalTable: "Planetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlienPoder",
                columns: table => new
                {
                    AlienId = table.Column<int>(type: "int", nullable: false),
                    PoderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlienPoder", x => new { x.AlienId, x.PoderId });
                    table.ForeignKey(
                        name: "FK_AlienPoder_Aliens_AlienId",
                        column: x => x.AlienId,
                        principalTable: "Aliens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlienPoder_Poderes_PoderId",
                        column: x => x.PoderId,
                        principalTable: "Poderes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlienPoder_PoderId",
                table: "AlienPoder",
                column: "PoderId");

            migrationBuilder.CreateIndex(
                name: "IX_Aliens_PlanetaId",
                table: "Aliens",
                column: "PlanetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlienPoder");

            migrationBuilder.DropTable(
                name: "Aliens");

            migrationBuilder.DropTable(
                name: "Poderes");

            migrationBuilder.DropTable(
                name: "Planetas");
        }
    }
}
