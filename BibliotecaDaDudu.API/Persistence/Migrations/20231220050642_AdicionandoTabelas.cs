using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaDaDudu.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Editora = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Autor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TotalVolumes = table.Column<int>(type: "int", nullable: false),
                    Sinopse = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Concluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Avaliacao = table.Column<decimal>(type: "decimal(18,0)", nullable: false, defaultValue: 0m),
                    StatusLeitura = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CapaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mangas_Imagens_CapaId",
                        column: x => x.CapaId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Avaliacao = table.Column<decimal>(type: "decimal(38,17)", nullable: false, defaultValue: 0m),
                    StatusLeitura = table.Column<int>(type: "int", nullable: false),
                    StatusCompra = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Sinopse = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    MangaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CapaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MangaEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volumes_Imagens_CapaId",
                        column: x => x.CapaId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volumes_Mangas_MangaEntityId",
                        column: x => x.MangaEntityId,
                        principalTable: "Mangas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_CapaId",
                table: "Mangas",
                column: "CapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_CapaId",
                table: "Volumes",
                column: "CapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_MangaEntityId",
                table: "Volumes",
                column: "MangaEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volumes");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Imagens");
        }
    }
}
