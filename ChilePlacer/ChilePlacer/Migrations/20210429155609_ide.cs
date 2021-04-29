using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class ide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GaleriaGirls_Girls_GirlsId",
                table: "GaleriaGirls");

            migrationBuilder.DropIndex(
                name: "IX_GaleriaGirls_GirlsId",
                table: "GaleriaGirls");

            migrationBuilder.DropColumn(
                name: "GirlsId",
                table: "GaleriaGirls");

            migrationBuilder.AddColumn<Guid>(
                name: "Identidad",
                table: "GaleriaGirls",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identidad",
                table: "GaleriaGirls");

            migrationBuilder.AddColumn<int>(
                name: "GirlsId",
                table: "GaleriaGirls",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GaleriaGirls_GirlsId",
                table: "GaleriaGirls",
                column: "GirlsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GaleriaGirls_Girls_GirlsId",
                table: "GaleriaGirls",
                column: "GirlsId",
                principalTable: "Girls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
