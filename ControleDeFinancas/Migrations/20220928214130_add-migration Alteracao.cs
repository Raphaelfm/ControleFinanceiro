using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeFinancas.Migrations
{
    public partial class addmigrationAlteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PrevisaoPagamento",
                table: "Contas_A_Pagar",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PrevisaoPagamento",
                table: "Contas_A_Pagar",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }
    }
}
