using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class KeyII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdGirls",
                table: "GaleriaGirls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGirls",
                table: "GaleriaGirls",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }
    }
}
