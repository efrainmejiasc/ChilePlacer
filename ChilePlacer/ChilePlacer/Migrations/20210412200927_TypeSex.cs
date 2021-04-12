using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class TypeSex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Girls",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Girls",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Girls",
                type: "VARCHAR(250)",
                nullable: false,
                defaultValue: "");

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
                name: "TypeSex");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Girls");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Girls");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Girls");
        }
    }
}
