using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class VarcharMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "ProfileGirls",
                type: "VARCHAR(8000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(400)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "ProfileGirls",
                type: "VARCHAR(400)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(8000)",
                oldNullable: true);
        }
    }
}
