using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class Cp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeCountry");

            migrationBuilder.DropTable(
                name: "TypeLocation");
        }
    }
}
