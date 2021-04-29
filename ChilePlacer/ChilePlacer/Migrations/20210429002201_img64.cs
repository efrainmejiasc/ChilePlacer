using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class img64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img64",
                table: "ProfileGirls",
                type: "VARCHAR(8000)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "PortadaGirls",
                type: "VARCHAR(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img64",
                table: "PortadaGirls",
                type: "VARCHAR(8000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img64",
                table: "GaleriaGirls",
                type: "VARCHAR(8000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img64",
                table: "ProfileGirls");

            migrationBuilder.DropColumn(
                name: "Img64",
                table: "PortadaGirls");

            migrationBuilder.DropColumn(
                name: "Img64",
                table: "GaleriaGirls");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "PortadaGirls",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldNullable: true);
        }
    }
}
