using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class RegistroGirl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Girls_TypeGirls_TypeGirlsId",
                table: "Girls");

            migrationBuilder.DropIndex(
                name: "IX_Girls_TypeGirlsId",
                table: "Girls");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Girls");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Girls");

            migrationBuilder.DropColumn(
                name: "TypeGirlsId",
                table: "Girls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TypeGirlsId",
                table: "Girls",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Girls_TypeGirlsId",
                table: "Girls",
                column: "TypeGirlsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Girls_TypeGirls_TypeGirlsId",
                table: "Girls",
                column: "TypeGirlsId",
                principalTable: "TypeGirls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
