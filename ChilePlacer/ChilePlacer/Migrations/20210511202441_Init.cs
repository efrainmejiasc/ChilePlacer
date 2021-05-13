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
                    FechaNacimiento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Dni = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Sexo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Username = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Presentacion = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Descripcion = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    CategoriaEscort = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Path = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    Img64 = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ValorHora = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    ValorMediaHora = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Estatura = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Peso = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Medidas = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Contextura = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Piel = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Hair = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Eyes = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Depilacion = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Drink = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Smoke = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Country = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Location = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Sector = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileGirls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAtencion",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atencion = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAtencion", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeAtencionGirl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identidad = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    TypeAtencion = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAtencionGirl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeContextura",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contextura = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeContextura", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeCountry",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCountry", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeDepilacion",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Depilacion = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDepilacion", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeDrink",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drink = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDrink", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeEscort",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEscort", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeEyes",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ojos = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEyes", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeGirls",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGirls", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeGirlServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identidad = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    TypeServices = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGirlServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeHair",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorCabello = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeHair", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeLocation",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Country = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLocation", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeNacionalidad",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nacionalidad = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNacionalidad", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypePiel",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Piel = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePiel", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeServicesSex",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servicio = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeServicesSex", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeSex",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sexo = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSex", x => x.Ide);
                });

            migrationBuilder.CreateTable(
                name: "TypeSmoke",
                columns: table => new
                {
                    Ide = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Smoke = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSmoke", x => x.Ide);
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
                name: "GaleriaGirlsAudio");

            migrationBuilder.DropTable(
                name: "GaleriaGirlsVideo");

            migrationBuilder.DropTable(
                name: "Girls");

            migrationBuilder.DropTable(
                name: "PortadaGirls");

            migrationBuilder.DropTable(
                name: "ProfileGirls");

            migrationBuilder.DropTable(
                name: "TypeAtencion");

            migrationBuilder.DropTable(
                name: "TypeAtencionGirl");

            migrationBuilder.DropTable(
                name: "TypeContextura");

            migrationBuilder.DropTable(
                name: "TypeCountry");

            migrationBuilder.DropTable(
                name: "TypeDepilacion");

            migrationBuilder.DropTable(
                name: "TypeDrink");

            migrationBuilder.DropTable(
                name: "TypeEscort");

            migrationBuilder.DropTable(
                name: "TypeEyes");

            migrationBuilder.DropTable(
                name: "TypeGirls");

            migrationBuilder.DropTable(
                name: "TypeGirlServices");

            migrationBuilder.DropTable(
                name: "TypeHair");

            migrationBuilder.DropTable(
                name: "TypeLocation");

            migrationBuilder.DropTable(
                name: "TypeNacionalidad");

            migrationBuilder.DropTable(
                name: "TypePiel");

            migrationBuilder.DropTable(
                name: "TypeServicesSex");

            migrationBuilder.DropTable(
                name: "TypeSex");

            migrationBuilder.DropTable(
                name: "TypeSmoke");
        }
    }
}
