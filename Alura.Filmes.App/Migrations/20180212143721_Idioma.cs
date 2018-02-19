using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alura.Filmes.App.Migrations
{
    public partial class Idioma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "length",
                table: "film",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<byte>(
                name: "language_id",
                table: "film",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "original_language_id",
                table: "film",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    category_id = table.Column<byte>(nullable: false),
                    name = table.Column<string>(type: "varchar(25)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "film_actor",
                columns: table => new
                {
                    film_id = table.Column<int>(nullable: false),
                    actor_id = table.Column<int>(nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_actor", x => new { x.film_id, x.actor_id });
                    table.ForeignKey(
                        name: "FK_film_actor_actor_actor_id",
                        column: x => x.actor_id,
                        principalTable: "actor",
                        principalColumn: "actor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_actor_film_film_id",
                        column: x => x.film_id,
                        principalTable: "film",
                        principalColumn: "film_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    language_id = table.Column<byte>(type: "tinyint", nullable: false),
                    name = table.Column<string>(type: "char(20)", nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "film_category",
                columns: table => new
                {
                    film_id = table.Column<int>(nullable: false),
                    category_id = table.Column<byte>(nullable: false),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_category", x => new { x.film_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_film_category_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_category_film_film_id",
                        column: x => x.film_id,
                        principalTable: "film",
                        principalColumn: "film_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_film_language_id",
                table: "film",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_original_language_id",
                table: "film",
                column: "original_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_actor_actor_id",
                table: "film_actor",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_category_category_id",
                table: "film_category",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_film_language_language_id",
                table: "film",
                column: "language_id",
                principalTable: "language",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film",
                column: "original_language_id",
                principalTable: "language",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_language_language_id",
                table: "film");

            migrationBuilder.DropForeignKey(
                name: "FK_film_language_original_language_id",
                table: "film");

            migrationBuilder.DropTable(
                name: "film_actor");

            migrationBuilder.DropTable(
                name: "film_category");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropIndex(
                name: "IX_film_language_id",
                table: "film");

            migrationBuilder.DropIndex(
                name: "IX_film_original_language_id",
                table: "film");

            migrationBuilder.DropColumn(
                name: "language_id",
                table: "film");

            migrationBuilder.DropColumn(
                name: "original_language_id",
                table: "film");

            migrationBuilder.AlterColumn<int>(
                name: "length",
                table: "film",
                nullable: false,
                oldClrType: typeof(short));
        }
    }
}
