using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FredRodriguez.Library.Travel.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FredRodriguez");

            migrationBuilder.CreateTable(
                name: "Autores",
                schema: "FredRodriguez",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Autores_Has_Libros",
                schema: "FredRodriguez",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    autor_id = table.Column<int>(type: "int", nullable: false),
                    libro_isbn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores_Has_Libros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                schema: "FredRodriguez",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sede = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                schema: "FredRodriguez",
                columns: table => new
                {
                    isbn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_Editorial = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sinopsis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    n_paginas = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.isbn);
                });

            migrationBuilder.InsertData(
                schema: "FredRodriguez",
                table: "Autores",
                columns: new[] { "id", "apellidos", "nombres" },
                values: new object[,]
                {
                    { 1, "Apellidos del autor 1", "Nombre del autor 1" },
                    { 2, "Apellidos del autor 2", "Nombre del autor 2" },
                    { 3, "Apellidos del autor 3", "Nombre del autor 3" },
                    { 4, "Apellidos del autor 4", "Nombre del autor 4" },
                    { 5, "Apellidos del autor 5", "Nombre del autor 5" },
                    { 6, "Apellidos del autor 6", "Nombre del autor 6" },
                    { 7, "Apellidos del autor 7", "Nombre del autor 7" },
                    { 8, "Apellidos del autor 8", "Nombre del autor 8" },
                    { 9, "Apellidos del autor 9", "Nombre del autor 9" }
                });

            migrationBuilder.InsertData(
                schema: "FredRodriguez",
                table: "Editoriales",
                columns: new[] { "id", "nombre", "sede" },
                values: new object[,]
                {
                    { 9, "Editorial 9", "Sede 9" },
                    { 8, "Editorial 8", "Sede 8" },
                    { 7, "Editorial 7", "Sede 7" },
                    { 6, "Editorial 6", "Sede 6" },
                    { 5, "Editorial 5", "Sede 5" },
                    { 4, "Editorial 4", "Sede 4" },
                    { 3, "Editorial 3", "Sede 3" },
                    { 2, "Editorial 2", "Sede 2" },
                    { 1, "Editorial 1", "Sede 1" }
                });

            migrationBuilder.InsertData(
                schema: "FredRodriguez",
                table: "Libros",
                columns: new[] { "isbn", "id", "id_Editorial", "n_paginas", "sinopsis", "titulo" },
                values: new object[,]
                {
                    { "978-958-5191-95-1", new Guid("c058d936-d710-409e-85eb-144ca9becc21"), 1, 10, "Sinopsis libro 1 ", "Libro 1" },
                    { "978-958-5191-95-2", new Guid("e97e5e09-c8cd-43be-92b4-6de0d99b91d0"), 2, 10, "Sinopsis libro 2 ", "Libro 2" },
                    { "978-958-5191-95-3", new Guid("9c3f2563-1e2a-42bd-892e-3b7a2a3121d3"), 3, 10, "Sinopsis libro 3 ", "Libro 3" },
                    { "978-958-5191-95-4", new Guid("43bc96d2-3518-4414-bce4-fae4c597e962"), 4, 10, "Sinopsis libro 4 ", "Libro 4" },
                    { "978-958-5191-95-5", new Guid("dabe8a40-b360-4c8d-8546-06f8b76ce46d"), 5, 10, "Sinopsis libro 5 ", "Libro 5" },
                    { "978-958-5191-95-6", new Guid("d7451a5a-052c-457d-b818-b8b640bc6d06"), 6, 10, "Sinopsis libro 6 ", "Libro 6" },
                    { "978-958-5191-95-7", new Guid("e86b5063-fe5b-4af1-8db2-e4cb5e1ab0af"), 7, 10, "Sinopsis libro 7 ", "Libro 7" },
                    { "978-958-5191-95-8", new Guid("58972b5d-b821-4b4b-88a7-6f179bb5c77a"), 8, 10, "Sinopsis libro 8 ", "Libro 8" },
                    { "978-958-5191-95-9", new Guid("599d310d-2a68-4214-aaed-f84e0f290dd5"), 9, 10, "Sinopsis libro 9 ", "Libro 9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_id",
                schema: "FredRodriguez",
                table: "Autores",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Editoriales_id",
                schema: "FredRodriguez",
                table: "Editoriales",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_isbn",
                schema: "FredRodriguez",
                table: "Libros",
                column: "isbn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores",
                schema: "FredRodriguez");

            migrationBuilder.DropTable(
                name: "Autores_Has_Libros",
                schema: "FredRodriguez");

            migrationBuilder.DropTable(
                name: "Editoriales",
                schema: "FredRodriguez");

            migrationBuilder.DropTable(
                name: "Libros",
                schema: "FredRodriguez");
        }
    }
}
