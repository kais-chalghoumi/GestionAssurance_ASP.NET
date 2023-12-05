using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAssurance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assurances",
                columns: table => new
                {
                    AssuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEffet = table.Column<DateTime>(type: "date", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "date", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assurances", x => x.AssuranceId);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomaineExpertise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifHoraire = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sinistres",
                columns: table => new
                {
                    SinistreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDeclaration = table.Column<DateTime>(type: "date", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssuranceFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinistres", x => x.SinistreId);
                    table.ForeignKey(
                        name: "FK_Sinistres_Assurances_AssuranceFK",
                        column: x => x.AssuranceFK,
                        principalTable: "Assurances",
                        principalColumn: "AssuranceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    DateExpertise = table.Column<DateTime>(type: "date", nullable: false),
                    ExpertFK = table.Column<int>(type: "int", nullable: false),
                    SinistreFK = table.Column<int>(type: "int", nullable: false),
                    AvisTechnique = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MontantEstime = table.Column<double>(type: "float", nullable: false),
                    Duree = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => new { x.ExpertFK, x.SinistreFK, x.DateExpertise });
                    table.ForeignKey(
                        name: "FK_Expertises_Experts_ExpertFK",
                        column: x => x.ExpertFK,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expertises_Sinistres_SinistreFK",
                        column: x => x.SinistreFK,
                        principalTable: "Sinistres",
                        principalColumn: "SinistreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SinistreFK",
                table: "Expertises",
                column: "SinistreFK");

            migrationBuilder.CreateIndex(
                name: "IX_Sinistres_AssuranceFK",
                table: "Sinistres",
                column: "AssuranceFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Sinistres");

            migrationBuilder.DropTable(
                name: "Assurances");
        }
    }
}
