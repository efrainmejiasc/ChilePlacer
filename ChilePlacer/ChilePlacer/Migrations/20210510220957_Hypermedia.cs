using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class Hypermedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GaleriaGirlsAudio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identidad = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PathAudio = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    Audio64 = table.Column<string>(type: "VARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriaGirlsAudio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaleriaGirlsVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identidad = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PathVideo = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    AVideo64 = table.Column<string>(type: "VARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriaGirlsVideo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaleriaGirlsAudio");

            migrationBuilder.DropTable(
                name: "GaleriaGirlsVideo");
        }
    }
}
