using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaDaDudu.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_Mangas_MangaEntityId",
                table: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Volumes_MangaEntityId",
                table: "Volumes");

            migrationBuilder.DropColumn(
                name: "MangaEntityId",
                table: "Volumes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Avaliacao",
                table: "Volumes",
                type: "decimal(38,17)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldDefaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_MangaId",
                table: "Volumes",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_Mangas_MangaId",
                table: "Volumes",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_Mangas_MangaId",
                table: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Volumes_MangaId",
                table: "Volumes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Avaliacao",
                table: "Volumes",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)",
                oldDefaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "MangaEntityId",
                table: "Volumes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_MangaEntityId",
                table: "Volumes",
                column: "MangaEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_Mangas_MangaEntityId",
                table: "Volumes",
                column: "MangaEntityId",
                principalTable: "Mangas",
                principalColumn: "Id");
        }
    }
}
