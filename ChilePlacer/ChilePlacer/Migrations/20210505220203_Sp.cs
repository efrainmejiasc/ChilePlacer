using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class Sp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeCountry");

            migrationBuilder.DropTable(
                name: "TypeLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeCountry",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Descripcion = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeLocation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Descripcion = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Location = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLocation", x => x.Id);
                });
        }
    }
}
