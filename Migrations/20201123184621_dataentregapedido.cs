using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mako.Migrations
{
    public partial class dataentregapedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PedidoEntregue",
                table: "Pedidos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidoEntregue",
                table: "Pedidos");
        }
    }
}
