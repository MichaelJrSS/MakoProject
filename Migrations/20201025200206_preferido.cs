using Microsoft.EntityFrameworkCore.Migrations;

namespace Mako.Migrations
{
    public partial class preferido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Preferido",
                table: "Produtos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preferido",
                table: "Produtos");
        }
    }
}
