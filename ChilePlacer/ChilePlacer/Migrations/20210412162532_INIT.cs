using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "GaleriaGirls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGirls = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PathImagen = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    TypeGirlsId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriaGirls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GaleriaGirls_TypeGirls_TypeGirlsId",
                        column: x => x.TypeGirlsId,
                        principalTable: "TypeGirls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Girls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identidad = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    TypeGirlsId = table.Column<int>(type: "INT", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Girls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Girls_TypeGirls_TypeGirlsId",
                        column: x => x.TypeGirlsId,
                        principalTable: "TypeGirls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GaleriaGirls_TypeGirlsId",
                table: "GaleriaGirls",
                column: "TypeGirlsId");

            migrationBuilder.CreateIndex(
                name: "IX_Girls_TypeGirlsId",
                table: "Girls",
                column: "TypeGirlsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaleriaGirls");

            migrationBuilder.DropTable(
                name: "Girls");

            migrationBuilder.DropTable(
                name: "TypeGirls");
        }
    }
}
