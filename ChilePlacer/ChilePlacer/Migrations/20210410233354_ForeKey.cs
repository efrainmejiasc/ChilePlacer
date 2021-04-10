using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class ForeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeGirlsId",
                table: "GaleriaGirls",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaleriaGirls_TypeGirlsId",
                table: "GaleriaGirls",
                column: "TypeGirlsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaleriaGirls_TypeGirls_TypeGirlsId",
                table: "GaleriaGirls",
                column: "TypeGirlsId",
                principalTable: "TypeGirls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaleriaGirls_TypeGirls_TypeGirlsId",
                table: "GaleriaGirls");

            migrationBuilder.DropIndex(
                name: "IX_GaleriaGirls_TypeGirlsId",
                table: "GaleriaGirls");

            migrationBuilder.DropColumn(
                name: "TypeGirlsId",
                table: "GaleriaGirls");
        }
    }
}
