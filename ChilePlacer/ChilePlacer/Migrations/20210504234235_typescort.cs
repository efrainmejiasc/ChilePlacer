using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class typescort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaEscort",
                table: "CategoriaEscort");

            migrationBuilder.RenameTable(
                name: "CategoriaEscort",
                newName: "TypeEscort");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeEscort",
                table: "TypeEscort",
                column: "Ide");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeEscort",
                table: "TypeEscort");

            migrationBuilder.RenameTable(
                name: "TypeEscort",
                newName: "CategoriaEscort");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaEscort",
                table: "CategoriaEscort",
                column: "Ide");
        }
    }
}
