using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilePlacer.Migrations
{
    public partial class roladm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RolAdm",
                table: "UserAdm",
                type: "VARCHAR(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RolAdm",
                table: "UserAdm");
        }
    }
}
