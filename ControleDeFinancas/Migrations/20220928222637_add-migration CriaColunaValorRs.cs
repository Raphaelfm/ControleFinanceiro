using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeFinancas.Migrations
{
    public partial class addmigrationCriaColunaValorRs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Contas_A_Pagar",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Contas_A_Pagar");
        }
    }
}
