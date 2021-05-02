using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Error = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangePassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangePassword", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GaleriaGirls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identidad = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PathImagen = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    Img64 = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Texto = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriaGirls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Girls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identidad = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Girls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortadaGirls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGirls = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PathImagen = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    Texto = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Img64 = table.Column<string>(type: "VARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortadaGirls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileGirls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identidad = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(80)", nullable: true),
                    Apellido = table.Column<string>(type: "VARCHAR(80)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Path = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Dni = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Username = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Img64 = table.Column<string>(type: "VARCHAR(8000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileGirls", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "TypeSex",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Sexo = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSex", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppLog");

            migrationBuilder.DropTable(
                name: "ChangePassword");

            migrationBuilder.DropTable(
                name: "GaleriaGirls");

            migrationBuilder.DropTable(
                name: "Girls");

            migrationBuilder.DropTable(
                name: "PortadaGirls");

            migrationBuilder.DropTable(
                name: "ProfileGirls");

            migrationBuilder.DropTable(
                name: "TypeGirls");

            migrationBuilder.DropTable(
                name: "TypeSex");
        }
    }
}
