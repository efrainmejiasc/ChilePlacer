using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaleriaGirls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGirls = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdTypeGirls = table.Column<int>(type: "INT", nullable: false),
                    PathImagen = table.Column<string>(type: "VARCHAR(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriaGirls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeGirls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGirls", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaleriaGirls");

            migrationBuilder.DropTable(
                name: "TypeGirls");
        }
    }
}
