using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class Key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaleriaGirls_TypeGirls_TypeGirlsId",
                table: "GaleriaGirls");

            migrationBuilder.RenameColumn(
                name: "TypeGirlsId",
                table: "GaleriaGirls",
                newName: "GirlsId");

            migrationBuilder.RenameIndex(
                name: "IX_GaleriaGirls_TypeGirlsId",
                table: "GaleriaGirls",
                newName: "IX_GaleriaGirls_GirlsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaleriaGirls_Girls_GirlsId",
                table: "GaleriaGirls",
                column: "GirlsId",
                principalTable: "Girls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaleriaGirls_Girls_GirlsId",
                table: "GaleriaGirls");

            migrationBuilder.RenameColumn(
                name: "GirlsId",
                table: "GaleriaGirls",
                newName: "TypeGirlsId");

            migrationBuilder.RenameIndex(
                name: "IX_GaleriaGirls_GirlsId",
                table: "GaleriaGirls",
                newName: "IX_GaleriaGirls_TypeGirlsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaleriaGirls_TypeGirls_TypeGirlsId",
                table: "GaleriaGirls",
                column: "TypeGirlsId",
                principalTable: "TypeGirls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
