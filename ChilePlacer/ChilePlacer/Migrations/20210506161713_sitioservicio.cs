using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class sitioservicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhatsApp",
                table: "ProfileGirls",
                newName: "CategoriaEscort");

            migrationBuilder.RenameColumn(
                name: "Atencion",
                table: "ProfileGirls",
                newName: "Nacionalidad");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "ProfileGirls",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "ProfileGirls",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "ProfileGirls",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nacionalidad",
                table: "ProfileGirls",
                newName: "Atencion");

            migrationBuilder.RenameColumn(
                name: "CategoriaEscort",
                table: "ProfileGirls",
                newName: "WhatsApp");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "ProfileGirls",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "ProfileGirls",
                type: "VARCHAR(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "ProfileGirls",
                type: "VARCHAR(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);
        }
    }
}
