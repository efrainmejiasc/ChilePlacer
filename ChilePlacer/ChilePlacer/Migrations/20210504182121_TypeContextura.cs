using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class TypeContextura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contextura",
                table: "Contextura");

            migrationBuilder.RenameTable(
                name: "Contextura",
                newName: "TypeContextura");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeContextura",
                table: "TypeContextura",
                column: "Ide");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeContextura",
                table: "TypeContextura");

            migrationBuilder.RenameTable(
                name: "TypeContextura",
                newName: "Contextura");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contextura",
                table: "Contextura",
                column: "Ide");
        }
    }
}
