using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class ForeKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaleriaGirls_TypeGirls_TypeGirlsId",
                table: "GaleriaGirls");

            migrationBuilder.DropColumn(
                name: "IdTypeGirls",
                table: "GaleriaGirls");

            migrationBuilder.AlterColumn<int>(
                name: "TypeGirlsId",
                table: "GaleriaGirls",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GaleriaGirls_TypeGirls_TypeGirlsId",
                table: "GaleriaGirls",
                column: "TypeGirlsId",
                principalTable: "TypeGirls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaleriaGirls_TypeGirls_TypeGirlsId",
                table: "GaleriaGirls");

            migrationBuilder.AlterColumn<int>(
                name: "TypeGirlsId",
                table: "GaleriaGirls",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<int>(
                name: "IdTypeGirls",
                table: "GaleriaGirls",
                type: "INT",
                nullable: false,
                defaultValue: 0);

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
